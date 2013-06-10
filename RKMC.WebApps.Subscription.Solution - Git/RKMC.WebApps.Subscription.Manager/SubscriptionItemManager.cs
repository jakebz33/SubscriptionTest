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
    public class SubscriptionItemManager : AppManager
    {
        #region GET METHODS

        protected SubscriptionItem GetItem(GetItemType SelectType, int SubscriptionID)
        {
            string strStoredProcName = "jsp_Subscription_GetSubscriptionItems";

            try
            {
                //notes:    set the parameters to use for this query
                ParameterCollection objParamCollection = new ParameterCollection();

                switch (SelectType)
                {
                    case GetItemType.BY_ID:
                        objParamCollection.Add((10).GetParameterListValue());
                        objParamCollection.Add(SubscriptionID.GetParameterInt("@SubscriptionID"));
                        break;
                }

                //notes:    get base object properties you want hydrated and add any additional if necessary
                ObjectPropertyDictionary objProperties = this.GetBaseProperties();

                //notes:    call local method to get object item
                return this.GetLocalItem(objParamCollection, objProperties, strStoredProcName);
            }
            catch (Exception ex)
            {
                return new SubscriptionItem { StatusResult = new ResponseStatus("Get Subscription Item Error: " + ex.Message, ex.StackTrace, ResponseStatusResult.Fail) };
            }
        }

        protected SubscriptionItemCollection GetCollection(GetItemType SelectType)
        {
            //notes:    return collection of groups
            string strStoredProcName = "jsp_Subscription_GetSubscriptionItems";

            try
            {
                //notes:    get base object properties you want hydrated and add any additional if necessary
                ObjectPropertyDictionary objProperties = this.GetBaseProperties();
                objProperties.Add("EmployeeName", SqlDbType.VarChar);

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
                return new SubscriptionItemCollection { StatusResult = new ResponseStatus("Get Subscription Collection Error: " + ex.Message, ex.StackTrace, ResponseStatusResult.Fail) };
            }
        }
        #endregion

        #region INSERT, UPDATE, DELETE METHODS

        protected void UpdateItem(SubscriptionItem SubscriptionItemObject, out ResponseStatus StatusResult)
        {
            string strStoredProcName = "jsp_Subscription_ExecuteResult";

            //notes:    ListValue options
            //          20 = UPDATE_ITEM
            try
            {
                //notes:    set the parameters to use for this query
                ParameterCollection objParamCollection = this.GetBaseParams(SubscriptionItemObject);
                objParamCollection.Add((20).GetParameterListValue());
                objParamCollection.Add(SubscriptionItemObject.SubscriptionID.GetParameterInt("@SubscriptionID"));

                //notes:    call data tier to update
                DataHelper.ExecuteDB(objParamCollection, strStoredProcName, base.GetConnectionString());

                //notes:    set out parameter
                StatusResult = new ResponseStatus("Update successful.", "ID = " + SubscriptionItemObject.SubscriptionID.ToString(), ResponseStatusResult.Success);
            }
            catch (Exception ex)
            {
                StatusResult = new ResponseStatus("Update failed.", ex.Message, ex.StackTrace, ResponseStatusResult.Fail);
            }
        }

        #endregion

        #region HELPER PRIVATE METHODS

        private ObjectPropertyDictionary GetBaseProperties()
        {
            ObjectPropertyDictionary objProperties = new ObjectPropertyDictionary();

            objProperties.Add("SubscriptionID", SqlDbType.Int);
            objProperties.Add("VendorID", SqlDbType.Int);
            objProperties.Add("VendorName", SqlDbType.VarChar);
            objProperties.Add("EmployeeID", SqlDbType.Int);
            objProperties.Add("Address", SqlDbType.VarChar);
            objProperties.Add("City", SqlDbType.VarChar);
            objProperties.Add("State", SqlDbType.VarChar);
            objProperties.Add("Zip", SqlDbType.Int);
            objProperties.Add("AccountNumber", SqlDbType.Int);
            objProperties.Add("BillingNumber", SqlDbType.VarChar);
            objProperties.Add("StartDate", SqlDbType.DateTime);
            objProperties.Add("EndDate", SqlDbType.DateTime);
            objProperties.Add("Paid", SqlDbType.VarChar);
            objProperties.Add("HomeAddress", SqlDbType.Bit);
            objProperties.Add("Notes", SqlDbType.VarChar);

            return objProperties;
        }

        private ParameterCollection GetBaseParams(SubscriptionItem ThisObject)
        {
            //notes:    set base parameters - used mostly for insert/update methods
            ParameterCollection objHelperParamList = new ParameterCollection();

            if (ThisObject.VendorID > 0)
                objHelperParamList.Add(ThisObject.VendorID.GetParameterInt("@VendorID"));

            if (ThisObject.EmployeeID > 0)
                objHelperParamList.Add(ThisObject.VendorID.GetParameterInt("@EmployeeID"));

            if (ThisObject.Address != null && ThisObject.Address.Trim().Length > 0)
                objHelperParamList.Add(ThisObject.Address.GetParameterVarchar("@Address", 100));

            if (ThisObject.City != null)
                objHelperParamList.Add(ThisObject.City.GetParameterVarchar("@City", 50));

            if (ThisObject.State != null)
                objHelperParamList.Add(ThisObject.State.GetParameterVarchar("@State", 50));

            if (ThisObject.Zip > 0)
                objHelperParamList.Add(ThisObject.Zip.GetParameterInt("@Zip"));

            if (ThisObject.AccountNumber > 0)
                objHelperParamList.Add(ThisObject.AccountNumber.GetParameterInt("@AccountNumber"));

            if (ThisObject.BillingNumber != null)
                objHelperParamList.Add(ThisObject.BillingNumber.GetParameterVarchar("@BillingNumber", 50));

            if (ThisObject.StartDate != DateTime.MinValue)
                objHelperParamList.Add(ThisObject.StartDate.GetParameterDateTime("@StartDate"));

            if (ThisObject.EndDate != DateTime.MinValue)
                objHelperParamList.Add(ThisObject.EndDate.GetParameterDateTime("@EndDate"));

            if (ThisObject.Paid != null)
                objHelperParamList.Add(ThisObject.Paid.GetParameterVarchar("@Paid", 50));

            return objHelperParamList;
        }

        private SubscriptionItemCollection GetLocalCollection(ParameterCollection ParameterCollection, ObjectPropertyDictionary PropertyValues, string StoredProcName)
        {
            List<Object> objGenericList = DataHelper.GetList<SubscriptionItem>(ParameterCollection, PropertyValues, StoredProcName, base.GetConnectionString());
            SubscriptionItemCollection objCollection = new SubscriptionItemCollection();

            foreach (Object item in objGenericList)
            {
                SubscriptionItem objItem = (SubscriptionItem)item;

                objCollection.Add(objItem);
            }

            objCollection.StatusResult = new ResponseStatus("Collection successful.", "", ResponseStatusResult.Success);
            return objCollection;
        }

        private SubscriptionItem GetLocalItem(ParameterCollection ParameterCollection, ObjectPropertyDictionary PropertyValues, string StoredProcName)
        {
            SubscriptionItem objItem = (SubscriptionItem)DataHelper.GetItem<SubscriptionItem>(ParameterCollection, PropertyValues, StoredProcName, base.GetConnectionString());

            //notes:    get embedded properties
            this.GetEmbeddedProperties(ref objItem);

            //notes:    return success indicator
            objItem.StatusResult = new ResponseStatus { ResponseStatusResult = ResponseStatusResult.Success };

            return objItem;
        }

        private void GetEmbeddedProperties(ref SubscriptionItem ThisObject)
        {
        }

        #endregion
    }
}
