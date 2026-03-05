using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverPay.Model.Sale
{
    public class IntegrationSaleItem
	{
		public string Name { get; set; }
		public bool IsGeneric { get; set; }
		public string UnitCode { get; set; }
		public string TaxGroupCode { get; set; }
		public decimal ItemQuantity { get; set; }
		public decimal UnitPriceAmount { get; set; }
		public decimal GrossPriceAmount { get; set; }
		public decimal TotalPriceAmount { get; set; }

    }
}
