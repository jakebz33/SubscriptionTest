using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RKMC.Base;
using RKMC.Base.Data;

namespace RKMC.Services.Common
{
    public class EmployeeManager : AppManager
    {
        #region GET METHODS

        protected Employee GetItem(GetItemType SelectType, int TKID, string FirstName, string LastName)
        {
            string strStoredProcName = "Elite_GetEmployee";

            try
            {
                //notes:    set the parameters to use for this query
                ParameterCollection objParamCollection = new ParameterCollection();

                //notes:    ListValue options
                switch (SelectType)
                {
                    case GetItemType.BY_TKID:
                        //          10 = GET_ITEM_BY_ID
                        objParamCollection.Add((10).GetParameterListValue());
                        objParamCollection.Add(TKID.GetParameterInt("@TKID"));
                        break;
                }

                //notes:    get base object properties you want hydrated and add any additional if necessary
                ObjectPropertyDictionary objProperties = this.GetBaseProperties();

                //notes:    call local method to get object item
                return this.GetLocalItem(objParamCollection, objProperties, strStoredProcName);
            }
            catch (Exception ex)
            {
                return new Employee { StatusResult = new ResponseStatus("Get Item by ID Error: " + ex.Message, ex.StackTrace, ResponseStatusResult.Fail) };
            }
        }
        protected EmployeeCollection GetCollection()
        {
            //notes:    return collection of groups
            string strStoredProcName = "Elite_GetEmployee";

            try
            {
                //notes:    set the parameters to use for this query
                ParameterCollection objParamCollection = new ParameterCollection();

                //notes:    ListValue options
                //          20 = GET_COLLECTION
                objParamCollection.Add((20).GetParameterListValue());

                //notes:    get base object properties you want hydrated and add any additional if necessary
                ObjectPropertyDictionary objProperties = this.GetBaseProperties();

                //notes:    call local method to get list
                return this.GetLocalCollection(objParamCollection, objProperties, strStoredProcName);
            }
            catch (Exception ex)
            {
                return new EmployeeCollection { StatusResult = new ResponseStatus("Get Employee Collection Error: " + ex.Message, ex.StackTrace, ResponseStatusResult.Fail) };
            }
        }
        protected EmployeeCollection GetCollection(GetItemType SelectType, string SearchString, int ReturnCount)
        {
            //notes:    return collection of groups
            string strStoredProcName = "Elite_GetEmployee";

            try
            {
                //notes:    get base object properties you want hydrated and add any additional if necessary
                ObjectPropertyDictionary objProperties = this.GetBaseProperties();
                objProperties.Add("label", SqlDbType.VarChar);
                objProperties.Add("value", SqlDbType.VarChar);

                //notes:    set the parameters to use for this query
                ParameterCollection objParamCollection = new ParameterCollection();
                objParamCollection.Add(ReturnCount.GetParameterInt("@ReturnCount"));


                switch (SelectType)
                {
                    case GetItemType.BY_SEARCH:
                        //          21 = GET_COLLECTION_BY_SEARCH
                        objParamCollection.Add((21).GetParameterListValue());
                        objParamCollection.Add(SearchString.GetParameterVarchar("@SearchString", 300));
                        break;
                }

                //notes:    call local method to get list
                return this.GetLocalCollection(objParamCollection, objProperties, strStoredProcName);
            }
            catch (Exception ex)
            {
                return new EmployeeCollection { StatusResult = new ResponseStatus("Get Employee Search Collection Error: " + ex.Message, ex.StackTrace, ResponseStatusResult.Fail) };
            }
        }

        #endregion


        #region INSERT, UPDATE, DELETE METHODS
        #endregion


        #region HELPER PRIVATE METHODS

        private void GetEmbeddedProperties(ref Employee ThisObject)
        {
            /*
            if (ThisObject.PatentNumber != null && ThisObject.PatentNumber.Length > 0)
            {
                //notes:    get associated classifications
                ThisObject.Classifications = new FlowManager.PatentClassificationFlow().GetClassificationCollection(ThisObject.PatentNumber);


                //notes:    get associated keywords
                ThisObject.Keywords = new FlowManager.KeywordFlow().GetPatentKeywords(ThisObject.PatentNumber);
            }
            */
        }
        private Employee GetLocalItem(ParameterCollection ParameterCollection, ObjectPropertyDictionary PropertyValues, string StoredProcName)
        {
            Employee objItem = (Employee)DataHelper.GetItem<Employee>(ParameterCollection, PropertyValues, StoredProcName, base.GetConnectionString());

            //notes:    get embedded properties
            this.GetEmbeddedProperties(ref objItem);

            //notes:    return success indicator
            objItem.StatusResult = new ResponseStatus("", "", ResponseStatusResult.Success);

            return objItem;
        }
        private EmployeeCollection GetLocalCollection(ParameterCollection ParameterCollection, ObjectPropertyDictionary PropertyValues, string StoredProcName)
        {
            List<Object> objGenericList = DataHelper.GetList<Employee>(ParameterCollection, PropertyValues, StoredProcName, base.GetConnectionString());
            EmployeeCollection objCollection = new EmployeeCollection();

            foreach (Object item in objGenericList)
            {
                Employee objItem = (Employee)item;

                //notes:    get embedded properties
                this.GetEmbeddedProperties(ref objItem);

                objCollection.Add(objItem);
            }

            objCollection.StatusResult = new ResponseStatus("", "", ResponseStatusResult.Success);
            return objCollection;
        }

        private ParameterCollection GetBaseParams(Employee ThisObject)
        {
            //notes:    set base parameters - used mostly for insert/update methods
            ParameterCollection objHelperParamList = new ParameterCollection();

            //if (ThisObject.PatentNumber != null)
            //    objHelperParamList.Add(ThisObject.PatentNumber.GetParameterVarchar("@PatentNumber", 10));

            return objHelperParamList;
        }
        private ObjectPropertyDictionary GetBaseProperties()
        {
            ObjectPropertyDictionary objProperties = new ObjectPropertyDictionary();

            objProperties.Add("TKID", SqlDbType.Int);

            objProperties.Add("Email", SqlDbType.VarChar);
            objProperties.Add("FirstName", SqlDbType.VarChar);
            objProperties.Add("LastName", SqlDbType.VarChar);
            objProperties.Add("Title", SqlDbType.VarChar);

            return objProperties;
        }

        #endregion
    }
}