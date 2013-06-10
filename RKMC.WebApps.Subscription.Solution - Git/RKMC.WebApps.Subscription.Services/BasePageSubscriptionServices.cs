using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using RKMC.Base;

namespace RKMC.WebApps.Subscription.Services
{
    public class BasePageSubscriptionServices : BasePage
    {
        #region PROPERTIES

        protected PageMode CurrentPageMode
        {
            get
            {
                bool _outIsNull;
                base.GetQueryStringID("MD", out _outIsNull);

                if (_outIsNull)
                    return PageMode.NONE;
                else
                    return base.GetQueryStringID("MD").EnumToNumber<PageMode>();
            }
        }
        protected string MethodName
        {
            get
            {
                bool _outIsNull;
                base.GetQueryString("MethodName", out _outIsNull);

                if (_outIsNull)
                    return string.Empty;
                else
                    return base.GetQueryString("MethodName");
            }
        }

        #endregion


        #region OUTPUT JSON

        protected void WriteJSON(Object OutputObject)
        {
            JavaScriptSerializer objJS = new JavaScriptSerializer();
            Response.Write(objJS.Serialize(OutputObject));
        }

        #endregion
    }
}