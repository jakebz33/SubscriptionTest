using System;
using System.Collections.Generic;
using System.Text;
using RKMC.Base;

namespace RKMC.Services.Common
{
    public class AppBO : BaseBO
    {
    }

    public enum GetItemType
    {
        BY_TKID,
        BY_FIRST_NAME,
        BY_FULL_NAME,
        BY_LAST_NAME,
        BY_SEARCH
    }
}