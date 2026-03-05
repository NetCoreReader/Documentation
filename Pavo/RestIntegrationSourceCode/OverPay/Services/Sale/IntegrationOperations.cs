using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OverPay.Global;
using OverPay.Model.Integration;
using OverPay.Model.Sale;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OverPay.Services.Sale
{
    public static class IntegrationOperations
    {
        private static int transactionSequence = 0;
        public static string refererApp = "Harici Uygulama";
        public static List<PaymentType> paymentTypes = new List<PaymentType>();
        public static ObservableCollection<ExternalPayment> externalPayments = new ObservableCollection<ExternalPayment>();
        public static List<IntegrationSale> completedSales = new List<IntegrationSale>();
        public static string SerialNumber;
        private static readonly ILog log = LogManager.GetLogger(typeof(App));
        public static TransactionHandle getTransactionHandle()
        {
            
            var transactionHandle = new TransactionHandle();
            transactionHandle.SerialNumber = SerialNumber;
            transactionHandle.TransactionDate = DateTime.Now;
            transactionHandle.TransactionSequence = ++transactionSequence;
            return transactionHandle;
        }

        public static OverPay.Model.Sale.IntegrationSale compareToIntegrationSale(OverPay.Model.Sale.Sale sale)
        {
            var integrationSale = new OverPay.Model.Sale.IntegrationSale();

            //integrationSale.Id = sale.Id;
            //integrationSale.SaleNumber = sale.SaleNumber;
            integrationSale.MainDocumentType = 1;
            integrationSale.RefererApp = "Rest Harici Uygulama";
            integrationSale.RefererAppVersion = "1";
            integrationSale.SendEMailNotification = sale.SendEMailNotification;
            integrationSale.SendPhoneNotification = sale.SendPhoneNotification;
            integrationSale.NotificationEMail = sale.NotificationEMail;
            integrationSale.NotificationPhone = sale.NotificationPhone;
            integrationSale.CancelReason = sale.CancelReason;
            integrationSale.GrossPrice = sale.TotalPrice.Value;
            integrationSale.TotalPrice = sale.TotalPrice;
            integrationSale.CurrencyCode = sale.CurrencyCode;
            integrationSale.ExchangeRate = sale.ExchangeRate;
            integrationSale.CustomerParty = sale.CustomerId != null ? new CustomerParty {
                Phone = sale.Customer.InvoicePhone,
                Address = sale.Customer.EInvoiceAddress,
                FirstName = sale.Customer.FirstName,
                TaxNumber = sale.Customer.TaxNumber,
                TaxOfficeCode = sale.Customer.TaxOffice != null ? sale.Customer.TaxOffice.Code : "001103",
                    City = "İstanbul",//sale.Customer.InvoiceAddress?.City?.Name,
                CompanyName = sale.Customer.InvoiceTitle,
                Country = "Türkiye",//sale.Customer.InvoiceAddress?.Country?.Name,
                CustomerType = sale.Customer.CustomerTypeId,
                District = "Başakşehir",//sale.Customer.InvoiceAddress?.District?.Name,
                EMail = sale.Customer.InvoiceEMail,
                FamilyName = sale.Customer.FamilyName,
                Neighborhood = sale.Customer.InvoiceAddress?.NeighborhoodId.ToString()
            } : null;

            foreach (var item in sale.AddedSaleItems)
            {
                var integrationSaleItem = new OverPay.Model.Sale.IntegrationSaleItem();
                integrationSaleItem.Name = item.Name;
                integrationSaleItem.IsGeneric = item.IsGeneric;
                integrationSaleItem.UnitCode = item.UBLCode;
                integrationSaleItem.TaxGroupCode = item.TaxGroup != null ? item.TaxGroup.Code : "KDV1";
                integrationSaleItem.ItemQuantity = item.ItemQuantity;
                integrationSaleItem.UnitPriceAmount = item.UnitPriceAmount;
                integrationSaleItem.GrossPriceAmount = item.GrossPriceAmount;
                integrationSaleItem.TotalPriceAmount = item.TotalPriceAmount.Value;

                integrationSale.AddedSaleItems.Add(integrationSaleItem);
            }

            integrationSale.ExternalPayments = externalPayments;
            return integrationSale;
        }


        public static async Task<PairingResponse> Paring()
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                initilazeConfig();
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    httpClient.BaseAddress = new Uri(RouteAddresses.FlutterBaseAddress);
                    var pairingRequest = IntegrationOperations.getTransactionHandle();
                    pairingRequest.TransactionSequence = 1;
                    var data = JsonConvert.SerializeObject(new
                    {
                        TransactionHandle = pairingRequest,
                    });
                    var pairingData = new StringContent(data, Encoding.UTF8, "application/json");
                    try
                    {

                        var response = await httpClient.PostAsync("/Pairing", pairingData);
                        string result = await response.Content.ReadAsStringAsync();
                        PairingResponse pairingResponse = JsonConvert.DeserializeObject<PairingResponse>(result);

                        if (!pairingResponse.HasError)
                        {
                            transactionSequence = 1;
                        }

                        return pairingResponse;

                    }
                    catch (Exception ex)
                    {
                        log.Error(String.Format("Pairing Errror: {0}", ex.Message));
                        throw ex;
                        //File.AppendAllText(filePath + "log.txt", ex.ToString());
                    }
                }
            }

        }

        public static async Task<string> StartSale()
        {
            externalPayments = new ObservableCollection<ExternalPayment>();
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    httpClient.BaseAddress = new Uri(RouteAddresses.FlutterBaseAddress);
                    var data = JsonConvert.SerializeObject(new
                    {
                        TransactionHandle = getTransactionHandle(),
                        Sale = new
                        {
                            MainDocumentType = 1,
                            GenericProductOnly = false,
                            RefererApp = refererApp,
                            RefererAppVersion = "1",
                        }
                    });
                    var pairingData = new StringContent(data, Encoding.UTF8, "application/json");
                    try
                    {

                        var response = await httpClient.PostAsync("/StartSale", pairingData);
                        var result = await response.Content.ReadAsStringAsync();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        log.Error(String.Format("Start sale Errror: {0}", ex.Message));
                        throw ex;
                    }
                }
            }

        }

        public static void initilazeConfig()
        {
            RouteAddresses.FlutterBaseAddress = ConfigurationSettings.AppSettings["IP"] + ":" + ConfigurationSettings.AppSettings["Port"];
            SerialNumber = ConfigurationSettings.AppSettings["SerialNumber"];
        }
    }

}
