using System;
using System.Collections.ObjectModel;
using System.Text;
using RKMC.Base;

namespace RKMC.WebApps.Subscription.BO
{
    public class SubscriptionItemCollection : Collection<SubscriptionItem>
    {
        public ResponseStatus StatusResult { get; set; }
    }

    public class VendorItemCollection : Collection<VendorItem>
    {
        public ResponseStatus StatusResult { get; set; }
    }
}
