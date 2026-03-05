using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverPay.Model.Integration
{
    public class TransactionHandle
    {
        public string SerialNumber { get; set; }
        public string Fingerprint { get; set; } = "test_fingerprint";
        public int TransactionSequence { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
