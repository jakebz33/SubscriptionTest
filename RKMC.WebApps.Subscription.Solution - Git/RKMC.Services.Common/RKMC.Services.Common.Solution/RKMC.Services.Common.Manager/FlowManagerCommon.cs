using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RKMC.Base;


namespace RKMC.Services.Common
{
    public class FlowManagerCommon
    {
        #region EMPLOYEE

        public class EmployeeFlow : EmployeeManager
        {
            public EmployeeCollection SearchEmployee(string SearchString)
            {
                return this.SearchEmployee(SearchString, 50);
            }
            public EmployeeCollection SearchEmployee(string SearchString, int ReturnCount)
            {
                if (SearchString != null && SearchString.Trim().Length > 0)
                {
                    if (ReturnCount <= 0)
                        ReturnCount = 50;

                    return base.GetCollection(GetItemType.BY_SEARCH, SearchString, ReturnCount);
                }
                else
                    return new EmployeeCollection { StatusResult = new ResponseStatus("No employee results.", "Search string was empty.", ResponseStatusResult.Fail) };
            }
        }

        #endregion
    }
}