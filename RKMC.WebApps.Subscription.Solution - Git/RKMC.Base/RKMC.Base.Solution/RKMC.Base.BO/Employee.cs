using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RKMC.Base
{
    public class Employee : Person
    {
        #region CONSTRUCTOR

        public Employee()
        {
        }
        public Employee(int EmployeeTKID)
        {
            this.TKID = EmployeeTKID;
        }
        public Employee(int EmployeeTKID, string EmployeeFirstName, string EmployeeLastName)
        {
            this.TKID = EmployeeTKID;
            this.FirstName = EmployeeFirstName;
            this.LastName = EmployeeLastName;
        }
        public Employee(int EmployeeTKID, string EmployeeFirstName, string EmployeeLastName, string EmployeeEmail)
        {
            this.TKID = EmployeeTKID;
            this.FirstName = EmployeeFirstName;
            this.LastName = EmployeeLastName;
            this.Email = EmployeeEmail;
        }

        #endregion


        public int TKID { get; set; }

        public string Email { get; set; }
        public string Title { get; set; }
    }
}
