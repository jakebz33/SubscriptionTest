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
using RKMC.WebApps.Subscription.Manager;
using RKMC.WebApps.Subscription.BO;

namespace RKMC.WebApps.Subscription.Services
{
    public partial class SubscriptionService : BasePageSubscriptionServices
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
                base.WriteJSON(new ResponseStatus("Execute subscription service failed.", "Method name is not specified.", ResponseStatusResult.Fail));
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
                this.WriteJSON(TypeUtil.InvokeStringMethod("RKMC.WebApps.Subscription.Services", "RKMC.WebApps.Subscription.Services", "ServiceSubscriptionHelper", base.MethodName.ToUpper(), objNameValues));
            }
        }

        #endregion
    }


    public class ServiceSubscriptionHelper
    {
        #region SELECT

        #endregion


        #region INSERT
        #endregion


        #region UPDATE

        public static Object SUBMITSUBSCRIPTION(NameValueCollection Parameters)
        {
            try
            {
                //notes:    only POST method processing
                if (Parameters["PageFormMethod"] == "POST")
                {
                    //notes:    FORM PARAMETERS
                    //          SubscriptionID:   int, required
                    //          EmployeeID:       int, required
                    //          Address:          string, not required
                    //          City:             string, not required
                    //          State:            string, not required
                    //          Zip:              int, not required
                    //          AccountNumber:    int, not required
                    //          BillingNumber:    string, not required
                    //          StartDate:        datetime, not required
                    //          EndDate:          datetime, not required
                    //          Paid:             string, not required
                    //          HomeAddress:      bool, not required
                    //          Notes:            string, not required


                    //notes:    verify that correct parameters were passed in
                    SubscriptionItem objItem = new SubscriptionItem();

                    objItem.SubscriptionID = Convert.ToInt32(Parameters["txtSubscriptionID"]);
                    objItem.EmployeeID = Convert.ToInt32(Parameters["txtPerson"]);
                    objItem.VendorID = Convert.ToInt32(Parameters["ddlVendor"]);
                    objItem.Address = Parameters["txtAddress"];
                    objItem.City = Parameters["txtCity"];
                    objItem.State = Parameters["txtState"];
                    objItem.Zip = Convert.ToInt32(Parameters["txtZip"]);
                    objItem.AccountNumber = Convert.ToInt32(Parameters["txtAccountNumber"]);
                    objItem.BillingNumber = Parameters["txtBillingNumber"];
                    objItem.StartDate = Convert.ToDateTime(Parameters["txtStartDate"]);
                    objItem.EndDate = Convert.ToDateTime(Parameters["txtEndDate"]);
                    objItem.Paid = Parameters["txtPaid"];
                    objItem.HomeAddress = Convert.ToBoolean(Convert.ToInt32(Parameters["rblAddress"]));
                    objItem.Notes = Parameters["txtNotes"];

                    ResponseStatus objStatus = new ResponseStatus();

                    new FlowManager.SubscriptionItemFlow().Update(objItem, out objStatus);
                    
                    //if (objStatus.ResponseStatusResult == ResponseStatusResult.Fail)
                    //    return objStatus;
                    //else
                        return objStatus;
                }
                else
                    return new ResponseStatus("Submit Subscription failed.", "Only POST method allowed.", ResponseStatusResult.Fail);
            }
            catch (Exception ex)
            {
                return new ResponseStatus("Submit Subscription failed.", ex.Message, ResponseStatusResult.Fail);
            }
        }

        #endregion


        #region DELETE
        #endregion
    }
}