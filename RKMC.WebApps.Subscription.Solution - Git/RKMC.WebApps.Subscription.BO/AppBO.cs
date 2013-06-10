using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using RKMC.Base;

namespace RKMC.WebApps.Subscription.BO
{

    public class AppBO : BaseBO
    {
    }

    public enum DataType
    {
        BOOLEAN = 10,
        DATETIME = 20,
        INT = 30,
        STRING = 40
    }
    public enum GetItemType
    {
        BY_ALL = 20,
        BY_CLASS = 0,
        BY_FIRM = 60,
        BY_ID = 10,
        BY_TKID = 22,
        BY_NAME = 30,
        BY_NUMBER = 40,
        BY_TYPE = 50,
        ON_FORM = 100,
        ON_DETAIL = 101
    }

}
