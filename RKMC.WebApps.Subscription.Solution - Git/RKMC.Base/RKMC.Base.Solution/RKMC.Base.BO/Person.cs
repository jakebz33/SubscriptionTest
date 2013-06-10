using System;
using System.Text;

namespace RKMC.Base
{
    public class Person : BaseBO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return this.FirstName + " " + this.LastName; } }
        public string FullNameLast { get { return this.LastName + ", " + this.FirstName; } }

        public string PreferredName { get; set; }
    }
}