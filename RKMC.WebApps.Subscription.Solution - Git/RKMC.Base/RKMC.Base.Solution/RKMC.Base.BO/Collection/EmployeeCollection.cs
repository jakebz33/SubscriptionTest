using System;
using System.Collections.ObjectModel;
using System.Text;

namespace RKMC.Base
{
    public class EmployeeCollection : Collection<Employee>
    {
        public ResponseStatus StatusResult { get; set; }
    }
}