using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RKMC.Base;
using RKMC.Base.Data;
using RKMC.WebApps.Subscription.BO;

namespace RKMC.WebApps.Subscription.Manager
{
    public class VendorItemManager : AppManager
    {
        #region GET METHODS

        protected VendorItem GetItem(GetItemType SelectType, int VendorID)
        {
            string strStoredProcName = "jsp_Subscription_GetVendorItems";

            try
            {
                //notes:    set the parameters to use for this query
                ParameterCollection objParamCollection = new ParameterCollection();

                switch (SelectType)
                {
                    case GetItemType.BY_ID:
                        objParamCollection.Add((10).GetParameterListValue());
                        objParamCollection.Add(VendorID.GetParameterInt("@VendorID"));
                        break;
                }

                //notes:    get base object properties you want hydrated and add any additional if necessary
                ObjectPropertyDictionary objProperties = this.GetBaseProperties();

                //notes:    call local method to get object item
                return this.GetLocalItem(objParamCollection, objProperties, strStoredProcName);
            }
            catch (Exception ex)
            {
                return new VendorItem { StatusResult = new ResponseStatus("Get Vendor Item Error: " + ex.Message, ex.StackTrace, ResponseStatusResult.Fail) };
            }
        }

        protected VendorItemCollection GetCollection(GetItemType SelectType)
        {
            //notes:    return collection of groups
            string strStoredProcName = "jsp_Subscription_GetVendorItems";

            try
            {
                //notes:    get base object properties you want hydrated and add any additional if necessary
                ObjectPropertyDictionary objProperties = this.GetBaseProperties();


                //notes:    set the parameters to use for this query
                ParameterCollection objParamCollection = new ParameterCollection();

                switch (SelectType)
                {
                    case GetItemType.BY_ALL:
                        objParamCollection.Add((20).GetParameterListValue());
                        break;
                }

                //notes:    call local method to get list
                return this.GetLocalCollection(objParamCollection, objProperties, strStoredProcName);
            }
            catch (Exception ex)
            {
                return new VendorItemCollection { StatusResult = new ResponseStatus("Get Vendor Collection Error: " + ex.Message, ex.StackTrace, ResponseStatusResult.Fail) };
            }
        }
        #endregion

        #region HELPER PRIVATE METHODS

        private ObjectPropertyDictionary GetBaseProperties()
        {
            ObjectPropertyDictionary objProperties = new ObjectPropertyDictionary();

            objProperties.Add("VendorID", SqlDbType.Int);
            objProperties.Add("VendorName", SqlDbType.VarChar);
            objProperties.Add("Address", SqlDbType.VarChar);
            objProperties.Add("City", SqlDbType.VarChar);
            objProperties.Add("State", SqlDbType.VarChar);
            objProperties.Add("Zip", SqlDbType.Int);
            objProperties.Add("Phone", SqlDbType.VarChar);
            objProperties.Add("Email", SqlDbType.VarChar);
            objProperties.Add("EliteVendorID", SqlDbType.Int);
            objProperties.Add("Billed", SqlDbType.VarChar);
            objProperties.Add("Delivered", SqlDbType.VarChar);
            objProperties.Add("Type", SqlDbType.VarChar);

            return objProperties;
        }

        private VendorItemCollection GetLocalCollection(ParameterCollection ParameterCollection, ObjectPropertyDictionary PropertyValues, string StoredProcName)
        {
            List<Object> objGenericList = DataHelper.GetList<VendorItem>(ParameterCollection, PropertyValues, StoredProcName, base.GetConnectionString());
            VendorItemCollection objCollection = new VendorItemCollection();

            foreach (Object item in objGenericList)
            {
                VendorItem objItem = (VendorItem)item;

                objCollection.Add(objItem);
            }

            objCollection.StatusResult = new ResponseStatus("Collection successful.", "", ResponseStatusResult.Success);
            return objCollection;
        }

        private VendorItem GetLocalItem(ParameterCollection ParameterCollection, ObjectPropertyDictionary PropertyValues, string StoredProcName)
        {
            VendorItem objItem = (VendorItem)DataHelper.GetItem<VendorItem>(ParameterCollection, PropertyValues, StoredProcName, base.GetConnectionString());

            //notes:    get embedded properties
            this.GetEmbeddedProperties(ref objItem);

            //notes:    return success indicator
            objItem.StatusResult = new ResponseStatus { ResponseStatusResult = ResponseStatusResult.Success };

            return objItem;
        }

        private void GetEmbeddedProperties(ref VendorItem ThisObject)
        {
        }

        #endregion
    }
}
