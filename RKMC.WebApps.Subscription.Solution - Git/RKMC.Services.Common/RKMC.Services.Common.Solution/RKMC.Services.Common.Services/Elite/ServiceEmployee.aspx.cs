using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using RKMC.Base;

namespace RKMC.Services.Common.Services
{
    public partial class ServiceEmployee : BasePageCommonServices
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //notes:    service call is required to be a POST
                /*
                if (Request.ServerVariables["REQUEST_METHOD"].ToUpper() == "POST")
                    this.ExecuteService();
                else
                    this.WriteJSON(new ResponseStatus("Service exception occurred.", "Invalid form submission method. Only POST method allowed.", ResponseStatusResult.Fail));
                */

                //DEBUG
                this.ExecuteService();
            }
            catch (Exception ex)
            {
                this.WriteJSON(new ResponseStatus("Service exception occurred.", ex.Message, ResponseStatusResult.Fail));
            }
        }


        #region EXECUTION

        private void ExecuteService()
        {
            //notes:    method name should be specified in the AJAX call from the UI
            if (base.MethodName.IsEmpty())
                base.WriteJSON(new ResponseStatus("Execute employee service failed.", "Method name is not specified.", ResponseStatusResult.Fail));
            else
            {
                NameValueCollection objParameterValues = new NameValueCollection();
                NameValueCollection objNameValues = new NameValueCollection();

                switch (base.GetFormMethod(Request.ServerVariables["REQUEST_METHOD"]))
                {
                    case FormMethod.GET:
                        //notes:    get name/value parameters from querystring collection
                        objParameterValues = Request.QueryString;

                        //notes:    add items to new collection
                        objNameValues.Add(objParameterValues);
                        objNameValues.Add("PageFormMethod", "GET");
                        break;

                    case FormMethod.POST:
                        //notes:    get name/value parameters from form collection
                        objParameterValues = Request.Form;

                        objNameValues.Add(objParameterValues);
                        objNameValues.Add("PageFormMethod", "POST");
                        break;

                    case FormMethod.NONE:
                        objNameValues.Add("PageFormMethod", "NONE");
                        break;
                }
                

                //notes:    invoke util to call dynamic method passing in name/value collection as parameters
                this.WriteJSON(TypeUtil.InvokeStringMethod("RKMC.Services.Common.Services", "RKMC.Services.Common.Services", "ServiceEmployeeHelper", base.MethodName.ToUpper(), objNameValues));
            }
        }

        #endregion
    }


    public class ServiceEmployeeHelper
    {
        #region SELECT

        public static Object GETAUTOCOMPLETEEMPLOYEE(NameValueCollection Parameters)
        {
            try
            {
                //notes:    QUERYSTRING PARAMETERS
                //          Term:   string, required


                //notes:    verify that correct parameters were passed in
                string _searchString = Parameters["Term"];

                EmployeeCollection objList = new FlowManagerCommon.EmployeeFlow().SearchEmployee(_searchString);
                if (objList.StatusResult.ResponseStatusResult == ResponseStatusResult.Success)
                    return objList;
                else
                    return objList.StatusResult;
            }
            catch (Exception ex)
            {
                return new ResponseStatus("Get Employee Collection failed.", ex.Message, ResponseStatusResult.Fail);
            }
        }
        public static Object GETSEARCHEMPLOYEE(NameValueCollection Parameters)
        {
            try
            {
                //notes:    only POST method processing
                if (Parameters["PageFormMethod"] == "POST")
                {
                    //notes:    FORM PARAMETERS
                    //          SearchString:   string, required
                    //          ReturnCount:    int, optional


                    //notes:    verify that correct parameters were passed in
                    string _searchString = Parameters["SearchString"];
                    string _paramReturnCount = string.Empty;
                    int _returnCount;

                    if (Parameters["ReturnCount"] != null)
                        _paramReturnCount = Parameters["ReturnCount"];

                    if (!_paramReturnCount.IsNumericGreaterThanZero(out _returnCount))
                        _returnCount = 0;

                    EmployeeCollection objList = new FlowManagerCommon.EmployeeFlow().SearchEmployee(_searchString, _returnCount);
                    if (objList.StatusResult.ResponseStatusResult == ResponseStatusResult.Success)
                        return objList;
                    else
                        return objList.StatusResult;
                }
                else
                    return new ResponseStatus("Get Employee Collection failed.", "Only POST method allowed.", ResponseStatusResult.Fail);
            }
            catch (Exception ex)
            {
                return new ResponseStatus("Get Employee Collection failed.", ex.Message, ResponseStatusResult.Fail);
            }
        }

        #endregion


        #region INSERT
        #endregion


        #region UPDATE
        #endregion


        #region DELETE
        #endregion
    }
}