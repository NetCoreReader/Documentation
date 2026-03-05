using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverPay.Model.Integration
{
    public class PairingResponse
    {
        public bool HasError { get; set; }
        public string Message { get; set; }
        public TransactionHandle TransactionHandle { get; set; }
        public List<string> Errors { get; set; }

    }
    /*
    public class BaseFields
    {
        public string SerialNumber { get; set; }
        public string Fingerprint { get; set; }
        public int TransactionSequence { get; set; }
        public DateTime TransactionDate { get; set; }
    }*/
}
