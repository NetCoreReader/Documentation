using OverPay.Model.Integration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverPay.Model.Sale
{
    public class IntegrationSale
	{
		public long Id { get; set; }
		public string SaleNumber { get; set; }
		public bool IsOffline { get; set; }
		public int MainDocumentType { get; set; }
		public string RefererApp { get; set; }
		public string RefererAppVersion { get; set; }
		public decimal GrossPrice { get; set; }
		public decimal? TotalPrice { get; set; }
		public string CancelReason { get; set; }
		public List<IntegrationSaleItem> AddedSaleItems { get; set; } = new List<IntegrationSaleItem>();
		public bool SendPhoneNotification { get; set; }
		public bool SendEMailNotification { get; set; }
		public string NotificationPhone { get; set; }
		public string NotificationEMail { get; set; }
		public CustomerParty CustomerParty { get; set; }
		public ObservableCollection<ExternalPayment> ExternalPayments { get; set; }
        public string CurrencyCode { get; set; }
        public double ExchangeRate { get; set; }
    }
}
