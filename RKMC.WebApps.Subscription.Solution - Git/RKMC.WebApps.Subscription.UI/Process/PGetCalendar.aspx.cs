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
    public partial class PGetCalendar : System.Web.UI.Page
    {
        SubscriptionItemCollection sic = new FlowManager.SubscriptionItemFlow().GetCollection();

        protected void Page_Load(object sender, EventArgs e)
        {
            BindCalendar();
        }

        private void BindCalendar()
        {
            SubscriptionCalendar.DayRender += new DayRenderEventHandler(this.DayRender);
        }

        private void DayRender(Object source, DayRenderEventArgs e)
        {
            if (sic.StatusResult.ResponseStatusResult == Base.ResponseStatusResult.Success)
            {
                var subscriptionExists = false;
                foreach (SubscriptionItem s in sic)
                {
                    if (e.Day.Date == s.EndDate.Date)
                    {
                        e.Cell.Controls.Add(new LiteralControl("<br /><a class=\"calendarVendor\" value=\"" + s.SubscriptionID + "\">" + s.EmployeeName + " (" + s.VendorName + ")</a><br />"));
                        subscriptionExists = true;
                    }
                }

                if (!subscriptionExists)
                {
                    e.Cell.Controls.Add(new LiteralControl("<div style=\"min-height: 90px;\"></div>"));
                }
            }
        }

    }
}