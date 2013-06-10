using System;
using System.Text;
using System.Reflection;

namespace RKMC.Base
{
    public class BaseBO
    {
        public int PagingTotalRecords { get; set; }
        public int RecordCount { get; set; }
        public ResponseStatus StatusResult { get; set; }

        public string label { get; set; }
        public string value { get; set; }


        //notes:    methods to programmatically set object properties and to retrieve values using reflection
        public void GetProperty(string PropertyName, out DateTime Value)
        {
            PropertyInfo info = this.GetType().GetProperty(PropertyName);
            Value = Convert.ToDateTime(info.GetValue(this, null));
        }
        public void GetProperty(string PropertyName, out bool Value)
        {
            PropertyInfo info = this.GetType().GetProperty(PropertyName);
            Value = Convert.ToBoolean(info.GetValue(this, null));
        }
        public void GetProperty(string PropertyName, out int Value)
        {
            PropertyInfo info = this.GetType().GetProperty(PropertyName);
            Value = Convert.ToInt32(info.GetValue(this, null));
        }
        public void GetProperty(string PropertyName, out string Value)
        {
            PropertyInfo info = this.GetType().GetProperty(PropertyName);

            if (info.GetValue(this, null) == null)
                Value = "";
            else
                Value = info.GetValue(this, null).ToString();
        }

        public void SetProperty(string PropertyName, bool Value)
        {
            PropertyInfo info = this.GetType().GetProperty(PropertyName);
            info.SetValue(this, Value, null);
        }
        public void SetProperty(string PropertyName, DateTime Value)
        {
            PropertyInfo info = this.GetType().GetProperty(PropertyName);
            info.SetValue(this, Value, null);
        }
        public void SetProperty(string PropertyName, int Value)
        {
            PropertyInfo info = this.GetType().GetProperty(PropertyName);
            info.SetValue(this, Value, null);
        }
        public void SetProperty(string PropertyName, string Value)
        {
            PropertyInfo info = this.GetType().GetProperty(PropertyName);
            info.SetValue(this, Value, null);
        }
    }


    #region ENUMS

    public enum FormMethod
    {
        NONE,
        GET,
        POST
    }
    public enum PageMode
    {
        NONE = 0,
        SELECT = 10,
        INSERT = 20,
        UPDATE = 30,
        DELETE = 40,
        AUTOCOMPLETE = 50
    }
    public enum ResponseStatusResult
    {
        Fail = 10,
        Success = 20
    }
    public enum UserType
    {
        None = 0,
        Admin = 10,
        User = 20,
        Delegate = 30,
        Contributor = 40,
        Manager = 50
    }

    #endregion
}