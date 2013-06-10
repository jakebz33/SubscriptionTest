using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace RKMC.Base
{
    public class BasePage : System.Web.UI.Page
    {
        #region PUBLIC METHODS

        //notes:    get method type
        public FormMethod GetFormMethod(string RequestServerVariable)
        {
            bool IsQueryStringNull;
            return this.GetFormMethod(RequestServerVariable, out IsQueryStringNull);
        }
        public FormMethod GetFormMethod(string RequestServerVariable, out bool IsRequestServerVariableNull)
        {
            FormMethod _Value = FormMethod.NONE;

            if (RequestServerVariable != null)
            {
                IsRequestServerVariableNull = false;

                switch (RequestServerVariable.ToUpper())
                {
                    case "GET":
                        _Value = FormMethod.GET;
                        break;

                    case "POST":
                        _Value = FormMethod.POST;
                        break;

                    default:
                        _Value = FormMethod.NONE;
                        break;
                }
            }
            else
                IsRequestServerVariableNull = true;


            return _Value;
        }


        //notes:    QUERYSTRING VALUES
        public bool GetQueryStringBool(string QueryStringName)
        {
            bool _OutValue;
            return this.GetQueryStringBool(QueryStringName, out _OutValue);
        }
        public bool GetQueryStringBool(string QueryStringName, out bool IsQueryStringNull)
        {
            bool _returnBool = false;

            if (Request.QueryString[QueryStringName] == null)
                IsQueryStringNull = true;
            else
            {
                IsQueryStringNull = false;
                string _StringBool = Request.QueryString[QueryStringName];

                _returnBool = _StringBool.IsBool();
            }

            return _returnBool;
        }

        public int GetQueryStringID(string QueryStringName)
        {
            bool _OutValue;
            return this.GetQueryStringID(QueryStringName, out _OutValue);
        }
        public int GetQueryStringID(string QueryStringName, out bool IsQueryStringNull)
        {
            int _ID = -1;

            if (Request.QueryString[QueryStringName] == null)
                IsQueryStringNull = true;
            else
            {
                IsQueryStringNull = false;
                string _StringID = Request.QueryString[QueryStringName];

                if (_StringID.IsNumeric())
                    _ID = Convert.ToInt32(_StringID);
            }

            return _ID;
        }

        public string GetQueryString(string QueryStringName)
        {
            bool _OutValue;
            return this.GetQueryString(QueryStringName, out _OutValue);
        }
        public string GetQueryString(string QueryStringName, out bool IsQueryStringNull)
        {
            string _Value = string.Empty;

            if (Request.QueryString[QueryStringName] == null)
                IsQueryStringNull = true;
            else
            {
                IsQueryStringNull = false;
                _Value = Request.QueryString[QueryStringName].Trim();
            }

            return _Value;
        }


        //notes:    FORM VALUES
        public bool GetFormBool(string FormStringName)
        {
            bool _OutValue;
            return this.GetFormBool(FormStringName, out _OutValue);
        }
        public bool GetFormBool(string FormStringName, out bool IsFormNull)
        {
            bool _Value = false;
            bool _OutValue = false;

            if (Request.Form[FormStringName] == null)
                IsFormNull = true;
            else
            {
                string _StringBoolean = Request.Form[FormStringName].Trim().ToUpper();

                if (_StringBoolean == "NULL")
                    IsFormNull = true;
                else
                {
                    IsFormNull = false;
                    _Value = Boolean.TryParse(this.GetBooleanStringValue(_StringBoolean).ToString(), out _OutValue);
                }
            }

            if (_OutValue)
                return _Value;
            else
                return false;
        }

        public DateTime GetFormDate(string FormStringName)
        {
            bool _OutValue;
            return this.GetFormDate(FormStringName, out _OutValue);
        }
        public DateTime GetFormDate(string FormStringName, out bool IsFormNull)
        {
            DateTime _OutValue = DateTime.MinValue;
            bool _ConversionSuccess;

            if (Request.Form[FormStringName] == null)
                IsFormNull = true;
            else
            {
                string _StringDateTime = Request.Form[FormStringName].Trim().ToUpper();

                if (_StringDateTime == "NULL")
                    IsFormNull = true;
                else
                {
                    IsFormNull = false;
                    _ConversionSuccess = DateTime.TryParse(_StringDateTime, out _OutValue);
                }
            }

            if (_OutValue == DateTime.MinValue)
                return DateTime.MinValue;
            else
                return _OutValue;
        }

        public int GetFormID(string FormStringName)
        {
            bool _OutValue;
            return this.GetFormID(FormStringName, out _OutValue);
        }
        public int GetFormID(string FormStringName, out bool IsFormNull)
        {
            int _ID = -1;

            if (Request.Form[FormStringName] == null)
                IsFormNull = true;
            else
            {
                string _StringID = Request.Form[FormStringName].Trim().ToUpper();

                //notes:    check for NULL value - indicates that value should be null when passing to database
                if (_StringID == "NULL")
                    IsFormNull = true;
                else
                {
                    IsFormNull = false;
                    if (_StringID.IsNumeric())
                        _ID = Convert.ToInt32(_StringID);
                }
            }

            return _ID;
        }
        
        public string GetFormString(string FormStringName)
        {
            bool _OutValue;
            return this.GetFormString(FormStringName, out _OutValue);
        }
        public string GetFormString(string FormStringName, out bool IsFormNull)
        {
            string _Value = string.Empty;

            if (Request.Form[FormStringName] == null)
                IsFormNull = true;
            else
            {
                string _StringValue = Request.Form[FormStringName].Trim().ToUpper();

                if (_StringValue == "NULL")
                    IsFormNull = true;
                else
                {
                    IsFormNull = false;
                    _Value = Request.Form[FormStringName].Trim();
                }
            }

            return _Value;
        }

        #endregion


        #region HELPER METHODS

        public void DisplayMessage(Label LabelControl, string Message, Boolean ShowMessage)
        {
            LabelControl.Text = Message;
            LabelControl.Visible = ShowMessage;
        }
        public bool GetBooleanStringValue(string BooleanText)
        {
            bool returnValue = false;

            switch (BooleanText.ToUpper())
            {
                case "TRUE":
                case "YES":
                case "YAY":
                case "YEA":
                case "YEAH":
                case "1":
                    returnValue = true;
                    break;

                case "FALSE":
                case "NO":
                case "NOPE":
                case "NAY":
                case "0":
                    returnValue = false;
                    break;

                default:
                    returnValue = false;
                    break;
            }

            return returnValue;
        }
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        #endregion
    }
}