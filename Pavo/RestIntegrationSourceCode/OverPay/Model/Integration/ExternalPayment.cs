using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverPay.Model.Integration
{
    public class ExternalPayment
    {
        public int Type { get; set; }
        public int Mediator { get; set; }
        public int Brand { get; set; }
        public decimal Amount { get; set; }
        public string CardNo { get; set; }
        public string AuthorizationCode { get; set; }
    }
}
