using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RKMC.WebApps.Subscription.Manager;
using RKMC.WebApps.Subscription.BO;
using RKMC.Base;

namespace RKMC.WebApps.Subscription.Solution.Process
{
    public partial class PGetSubscription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string subscriptionID = Request.QueryString["SubscriptionID"];
            BindData(subscriptionID);
        }

        #region BIND CONTROLS

        private void BindData(string subscriptionID)
        {
            if (subscriptionID != "" && subscriptionID != null)
            {
                SubscriptionItem objItem;
                objItem = new FlowManager.SubscriptionItemFlow().GetItem(Convert.ToInt32(subscriptionID));

                VendorItemCollection vendorList = new FlowManager.VendorItemFlow().GetCollection();
                ddlVendor.DataSource = vendorList;
                ddlVendor.DataValueField = "VendorID";
                ddlVendor.DataTextField = "VendorName";
                ddlVendor.DataBind();

                //notes:    check collection status and bind to repeater
                if (objItem.StatusResult.ResponseStatusResult == Base.ResponseStatusResult.Success)
                {
                    if (objItem != null)
                    {
                        txtSubscriptionID.Text = objItem.SubscriptionID.ToString();
                        txtPerson.Text = objItem.EmployeeName;
                        ddlVendor.SelectedValue = objItem.VendorID.ToString();
                        rbHome.Checked = objItem.HomeAddress ? true : false;
                        txtAddress.Text = objItem.Address;
                        txtCity.Text = objItem.City;
                        txtState.Text = objItem.State;
                        txtZip.Text = objItem.Zip.ToString();
                        txtAccountNumber.Text = objItem.AccountNumber.ToString();
                        txtBillingNumber.Text = objItem.BillingNumber.ToString();
                        txtStartDate.Text = objItem.StartDate.ToShortDateString();
                        txtEndDate.Text = objItem.EndDate.ToShortDateString();
                        txtPaid.Text = objItem.Paid;
                        txtNotes.Text = objItem.Notes;
                    }
                    else
                        this.DisplayPageMessage("No subscription data is available at this time.");
                }
                else
                    this.DisplayPageMessage(objItem.StatusResult.Message);
            }
        }

        private void DisplayPageMessage(string Message)
        {
            litPageMessage.Visible = true;
            litPageMessage.Text = Message;
        }

        #endregion

        #region EVENT HANDLERS


        #endregion

    }
}