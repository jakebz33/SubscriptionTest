using System;
using System.Text;
using System.Data.SqlClient;
using System.Globalization;
using System.Text.RegularExpressions;

namespace RKMC.Base
{
    public static class ExtensionMethods
    {
        public static SqlParameter GetParameterBoolInt(this bool Value, string ParameterName)
        {
            SqlParameter objParam = new SqlParameter(ParameterName, System.Data.SqlDbType.Int);
            objParam.Value = Value;

            return objParam;
        }
        public static SqlParameter GetParameterBoolInt(this bool? Value, string ParameterName)
        {
            SqlParameter objParam = new SqlParameter(ParameterName, System.Data.SqlDbType.Int);
            objParam.Value = Value;

            return objParam;
        }
        public static SqlParameter GetParameterDateTime(this DateTime Value, string ParameterName)
        {
            SqlParameter objParam = new SqlParameter(ParameterName, System.Data.SqlDbType.DateTime);
            objParam.Value = Value;

            return objParam;
        }
        public static SqlParameter GetParameterListValue(this int Value)
        {
            SqlParameter objParam = new SqlParameter("@ListValue", System.Data.SqlDbType.Int);
            objParam.Value = Value;

            return objParam;
        }
        public static SqlParameter GetParameterInt(this int Value, string ParameterName)
        {
            SqlParameter objParam = new SqlParameter(ParameterName, System.Data.SqlDbType.Int);
            objParam.Value = Value;

            return objParam;
        }
        public static SqlParameter GetParameterVarchar(this string Value, string ParameterName, int ParameterLength)
        {
            SqlParameter objParam = new SqlParameter(ParameterName, System.Data.SqlDbType.VarChar, ParameterLength);
            objParam.Value = Value;

            return objParam;
        }

        public static T EnumToNumber<T>(this int Value)
        {
            return (T)Enum.ToObject(typeof(T), Value);
        }

        public static bool IsBool(this string Value)
        {
            if (Value == null)
                return false;
            else
            {
                switch (Value.ToUpper())
                {
                    case "YES":
                    case "TRUE":
                    case "1":
                    case "YEAH":
                    case "YEA":
                    case "YAY":
                        return true;


                    case "NO":
                    case "FALSE":
                    case "0":
                    case "NOPE":
                    case "NAY":
                        return false;


                    default:
                        return false;
                }
            }
        }
        public static bool IsDecimal(this string Value)
        {
            try
            {
                Decimal.Parse(Value.Trim());
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool IsEmpty(this string Value)
        {
            if (Value == null)
                return true;
            else
            {
                if (Value.Trim().Length > 0)
                    return false;
                else
                    return true;
            }
        }
        public static bool IsNumeric(this string Value)
        {
            try
            {
                Convert.ToInt32(Value);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool IsNumericGreaterThanZero(this string Value, out int IntValue)
        {
            try
            {
                IntValue = 0;

                if (Value.IsNumeric())
                {
                    int _intValue = Convert.ToInt32(Value);
                    if (_intValue > 0)
                    {
                        IntValue = _intValue;
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            catch
            {
                IntValue = 0;
                return false;
            }
        }
        public static bool IsDate(this string Value)
        {
            try
            {
                Convert.ToDateTime(Value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string[] SplitString(this string Value, string Separator)
        {
            char[] charSeparator = new char[] { Convert.ToChar(Separator) };
            return Value.Split(charSeparator, StringSplitOptions.RemoveEmptyEntries);
        }


        //notes:    email check methods
        public static bool IsValidEmail(this string Value)
        {
            bool bolInvalidEmail = false;
            if (String.IsNullOrEmpty(Value))
                return false;

            //notes:    use IdnMapping class to convert Unicode domain names.
            Value = Regex.Replace(Value, @"(@)(.+)$", ExtensionMethods.DomainMapper);
            if (bolInvalidEmail)
                return false;

            //notes:    return true if strIn is in valid e-mail format.
            return Regex.IsMatch(Value,
                   @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                   @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",
                   RegexOptions.IgnoreCase);
        }
        public static string DomainMapper(Match match)
        {
            //notes:    IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();
            bool bolInvalidEmail = false;

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                bolInvalidEmail = true;
            }
            return match.Groups[1].Value + domainName;
        }


        //notes:    get month name methods
        public static string GetMonthName(this DateTime Value)
        {
            string strReturnValue = string.Empty;

            switch (Value.Month)
            {
                case 1:
                    strReturnValue = "January";
                    break;
                case 2:
                    strReturnValue = "February";
                    break;
                case 3:
                    strReturnValue = "March";
                    break;
                case 4:
                    strReturnValue = "April";
                    break;
                case 5:
                    strReturnValue = "May";
                    break;
                case 6:
                    strReturnValue = "June";
                    break;
                case 7:
                    strReturnValue = "July";
                    break;
                case 8:
                    strReturnValue = "August";
                    break;
                case 9:
                    strReturnValue = "September";
                    break;
                case 10:
                    strReturnValue = "October";
                    break;
                case 11:
                    strReturnValue = "November";
                    break;
                case 12:
                    strReturnValue = "December";
                    break;
            }

            return strReturnValue;
        }
        public static string GetMonthNameAbbr(this DateTime Value)
        {
            string strReturnValue = string.Empty;

            switch (Value.Month)
            {
                case 1:
                    strReturnValue = "Jan";
                    break;
                case 2:
                    strReturnValue = "Feb";
                    break;
                case 3:
                    strReturnValue = "Mar";
                    break;
                case 4:
                    strReturnValue = "Apr";
                    break;
                case 5:
                    strReturnValue = "May";
                    break;
                case 6:
                    strReturnValue = "Jun";
                    break;
                case 7:
                    strReturnValue = "Jul";
                    break;
                case 8:
                    strReturnValue = "Aug";
                    break;
                case 9:
                    strReturnValue = "Sep";
                    break;
                case 10:
                    strReturnValue = "Oct";
                    break;
                case 11:
                    strReturnValue = "Nov";
                    break;
                case 12:
                    strReturnValue = "Dec";
                    break;
            }

            return strReturnValue;
        }
    }
}