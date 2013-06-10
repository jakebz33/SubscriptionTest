using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RKMC.Base;

namespace RKMC.WebApps.Subscription.BO
{
    public class VendorItem : BaseBO
    {
        public int      VendorID { get; set; }
        public string   VendorName { get; set; }
        public string   Address { get; set; }
        public string   City { get; set; }
        public string   State { get; set; }
        public int      Zip { get; set; }
        public string   Phone { get; set; }
        public string   Email { get; set; }
        public int      EliteVendorID { get; set; }
        public string   Billed { get; set; }
        public string   Delivered { get; set; }
        public string   Type { get; set; }
    }
}
