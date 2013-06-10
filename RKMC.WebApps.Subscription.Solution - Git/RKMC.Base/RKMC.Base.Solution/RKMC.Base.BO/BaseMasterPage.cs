using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace RKMC.Base
{
    public class BaseMasterPage : System.Web.UI.MasterPage
    {
        #region PUBLIC METHODS

        public string GetQueryString(string QueryStringName)
        {
            string _Value = string.Empty;

            if (Request.QueryString[QueryStringName] != null)
                _Value = Request.QueryString[QueryStringName];

            return _Value;
        }
        public int GetQueryStringID(string QueryStringName)
        {
            int _ID = -1;

            if (Request.QueryString[QueryStringName] != null)
            {
                string _StringID = Request.QueryString[QueryStringName];

                if (_StringID.IsNumeric())
                    _ID = Convert.ToInt32(_StringID);
            }

            return _ID;
        }

        #endregion


        #region HELPER METHODS

        public void DisplayMessage(Label LabelControl, string Message, Boolean ShowMessage)
        {
            LabelControl.Text = Message;
            LabelControl.Visible = ShowMessage;
        }

        #endregion
    }
}