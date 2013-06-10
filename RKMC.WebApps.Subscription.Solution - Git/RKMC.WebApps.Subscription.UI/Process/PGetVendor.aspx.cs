using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RKMC.WebApps.Subscription.Manager;
using RKMC.WebApps.Subscription.BO;

namespace RKMC.WebApps.Subscription.Solution.Process
{
    public partial class PGetVendor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }

        #region BIND CONTROLS

        private void BindData()
        {
            VendorItem objItem;

            objItem = new FlowManager.VendorItemFlow().GetItem(Convert.ToInt32(Request.QueryString["VendorID"]));

            //notes:    check collection status and bind to repeater
            if (objItem.StatusResult.ResponseStatusResult == Base.ResponseStatusResult.Success)
            {
                if (objItem != null)
                {
                    txtVendorID.Text = objItem.VendorID.ToString();
                    txtVendorName.Text = objItem.VendorName;
                    txtAddress.Text = objItem.Address;
                    txtCity.Text = objItem.City;
                    txtState.Text = objItem.State;
                    txtZip.Text = objItem.Zip.ToString();
                    txtPhone.Text = objItem.Phone;
                    txtEmail.Text = objItem.Email;
                    txtEliteVendorID.Text = objItem.EliteVendorID.ToString();
                    txtBilled.Text = objItem.Billed;
                    txtDelivered.Text = objItem.Delivered;
                    txtType.Text = objItem.Type;
                }
                else
                    this.DisplayPageMessage("No vendor data is available at this time.");
            }
            else
                this.DisplayPageMessage(objItem.StatusResult.Message);
        }

        private void DisplayPageMessage(string Message)
        {
            litPageMessage.Visible = true;
            litPageMessage.Text = Message;
        }

        #endregion
    }
}