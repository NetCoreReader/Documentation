using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OverPay.Global;
using OverPay.Model.Integration;
using OverPay.Model.Response;
using OverPay.Model.Sale;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OverPay.Services.Sale
{
    public class SaleService
    {
        private OverPay.Services.HttpClientHeader.HttpClientHeader httpClientHeader;
        public SaleService()
        {
            this.httpClientHeader = new OverPay.Services.HttpClientHeader.HttpClientHeader();

        }

        public async Task<string> Create(OverPay.Model.Sale.Sale sale)
        {
            return await IntegrationOperations.StartSale();
        }

        public async Task<string> CompleteSale(OverPay.Model.Sale.Sale sale)
        {
            var integrationData = IntegrationOperations.compareToIntegrationSale(sale);

            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    httpClient.BaseAddress = new Uri(RouteAddresses.FlutterBaseAddress);
                    var data = JsonConvert.SerializeObject(new
                    {
                        TransactionHandle = IntegrationOperations.getTransactionHandle(),
                        Sale = integrationData
                    });
                    var pairingData = new StringContent(data, Encoding.UTF8, "application/json");
                    try
                    {

                        var response = await httpClient.PostAsync("/CompleteSale", pairingData);
                        var result = response.Content.ReadAsStringAsync().Result;

                        return result;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

        }
        
        public async Task<string> CancelSale(IntegrationSale sale)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    httpClient.BaseAddress = new Uri(RouteAddresses.FlutterBaseAddress);
                    var data = JsonConvert.SerializeObject(new
                    {
                        TransactionHandle = IntegrationOperations.getTransactionHandle(),
                        Sale = new {
                            Id = sale.Id,
                            SaleNumber = sale.SaleNumber,
                            IsOffline = sale.IsOffline,
                        }
                    });
                    var pairingData = new StringContent(data, Encoding.UTF8, "application/json");
                    try
                    {

                        var response = await httpClient.PostAsync("/CancelSale", pairingData);
                        var result = response.Content.ReadAsStringAsync().Result;

                        return result;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

        }

        public async Task<string> AbondedlSale(Model.Sale.Sale sale)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    httpClient.BaseAddress = new Uri(RouteAddresses.FlutterBaseAddress);
                    var data = JsonConvert.SerializeObject(new
                    {
                        TransactionHandle = IntegrationOperations.getTransactionHandle(),
                        Sale = new
                        {
                            Id = sale.Id,
                            SaleNumber = sale.SaleNumber,
                            IsOffline = sale.IsOffline,
                        }
                    });
                    var pairingData = new StringContent(data, Encoding.UTF8, "application/json");
                    try
                    {

                        var response = await httpClient.PostAsync("/CancelSale", pairingData);
                        var result = response.Content.ReadAsStringAsync().Result;

                        return result;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

        }


        public async Task<string> StartPayment(OverPay.Model.Sale.IntegrationSale integrationSale)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    httpClient.BaseAddress = new Uri(RouteAddresses.FlutterBaseAddress);
                    var transactionHadle = IntegrationOperations.getTransactionHandle();
                    var data = JsonConvert.SerializeObject(new
                    {
                        transactionHadle,
                        integrationSale

                    });
                    var pairingData = new StringContent(data, Encoding.UTF8, "application/json");
                    try
                    {

                        var response = await httpClient.PostAsync("/StartPayment", pairingData);
                        var result = response.Content.ReadAsStringAsync().Result;
                        return result;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

        }


    }
}
