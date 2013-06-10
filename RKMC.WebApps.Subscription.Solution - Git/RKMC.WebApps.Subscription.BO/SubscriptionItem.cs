using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RKMC.Base;

namespace RKMC.WebApps.Subscription.BO
{
    public class SubscriptionItem : BaseBO
    {
        public int SubscriptionID { get; set; }
        public int VendorID { get; set; }
        public string VendorName { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public int AccountNumber { get; set; }
        public string BillingNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Paid { get; set; }
        public bool HomeAddress { get; set; }
        public string Notes { get; set; }
    }
}