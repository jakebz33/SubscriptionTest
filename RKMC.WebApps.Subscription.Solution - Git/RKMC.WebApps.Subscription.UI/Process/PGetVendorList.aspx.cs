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
    public partial class PGetVendorList : System.Web.UI.Page
    {
        private int _TableColspan = 12;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.BindResults();
            }
            catch (Exception ex)
            {
                this.DisplayPageMessage(ex.Message);
            }
        }

        #region BIND CONTROLS

        private void BindResults()
        {
            VendorItemCollection objCollection;

            objCollection = new FlowManager.VendorItemFlow().GetCollection();

            //notes:    check collection status and bind to repeater
            if (objCollection.StatusResult.ResponseStatusResult == Base.ResponseStatusResult.Success)
            {
                if (objCollection.Count > 0)
                {
                    rptVendors.Visible = true;
                    rptVendors.DataSource = objCollection;
                    rptVendors.DataBind();
                }
                else
                    this.DisplayPageMessage("No vendors are available at this time.");
            }
            else
                this.DisplayPageMessage(objCollection.StatusResult.Message);
        }

        private void DisplayPageMessage(string Message)
        {
            litPageMessage.Visible = true;
            litPageMessage.Text = "<tr><td align='center' colspan='" + _TableColspan + "'>" + Message + "</td></tr>";

            rptVendors.Visible = false;
        }

        #endregion


        #region EVENT HANDLERS

        protected void Repeater_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            VendorItem objItem = (VendorItem)item.DataItem;
            //string strDateAdded = "";

            if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
            {
                Literal litEditButton = (Literal)e.Item.FindControl("litEditButton");

                //notes:    output edit button
                litEditButton.Text = "<input type='button' class='button' value='Edit' id='EditVendorButton' style='height:14px;width:50px;line-height:10px;padding:0;margin:0;' title='" + objItem.VendorName + "' dir='" + objItem.VendorID.ToString() + "' />";
            }
        }

        #endregion
    }
}