using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverPay.Model.Integration
{
    public class CustomerParty
    {
        public int CustomerType { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string FamilyName { get; set; }
        public string CompanyName { get; set; }
        public string TaxOfficeCode { get; set; }
        public string TaxNumber { get; set; }
        public string Phone { get; set; }
        public string EMail { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Neighborhood { get; set; }
        public string Address { get; set; }
    }
}
