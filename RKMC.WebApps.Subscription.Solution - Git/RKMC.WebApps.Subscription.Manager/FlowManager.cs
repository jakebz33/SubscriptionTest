using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Net.Mail;
using RKMC.Base;
using RKMC.WebApps.Subscription.BO;

namespace RKMC.WebApps.Subscription.Manager
{
    public class FlowManager
    {

        #region SubscriptionItem

        public class SubscriptionItemFlow : SubscriptionItemManager
        {
            //notes:    get collections
            public SubscriptionItemCollection GetCollection()
            {
                    return base.GetCollection(GetItemType.BY_ALL);
            }

            //notes:    get single item
            public SubscriptionItem GetItem(int SubscriptionID)
            {
                return base.GetItem(GetItemType.BY_ID, SubscriptionID);
            }

            //notes:    insert, update, delete
            public void Update(SubscriptionItem ObjectSubscriptionItem, out ResponseStatus StatusResult)
            {
                if (ObjectSubscriptionItem.SubscriptionID > 0)
                    base.UpdateItem(ObjectSubscriptionItem, out StatusResult);
                else
                {
                    //notes:    TODO: insert
                    base.UpdateItem(ObjectSubscriptionItem, out StatusResult);
                }
            }
        }

        #endregion

        #region VendorItem

        public class VendorItemFlow : VendorItemManager
        {
            //notes:    get collections
            public VendorItemCollection GetCollection()
            {
                return base.GetCollection(GetItemType.BY_ALL);
            }

            //notes:    get single item
            public VendorItem GetItem(int VendorID)
            {
                return base.GetItem(GetItemType.BY_ID, VendorID);
            }
        }

        #endregion
    }
}
