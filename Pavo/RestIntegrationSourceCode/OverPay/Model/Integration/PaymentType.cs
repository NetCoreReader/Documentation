using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverPay.Model.Integration
{
    public class PaymentType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<PaymentMediator> PaymentMediators { get; set; }
    }
    public class PaymentMediator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PaymentTypeId { get; set; }
        public bool IsExternal { get; set; }
        public decimal? AllowedVATRate { get; set; }
        public List<PaymentProviderBrand> PaymentProviderBrands { get; set; }
    }

    public class PaymentProviderBrand
    {
        public int Id { get; set; }
        public string PaymentProviderBrandName { get; set; }
        public int PaymentMediatorId { get; set; }
        public string Comment { get; set; }
    }
}
