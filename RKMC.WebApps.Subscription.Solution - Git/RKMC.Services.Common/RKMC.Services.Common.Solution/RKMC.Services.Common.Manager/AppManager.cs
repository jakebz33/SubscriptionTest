﻿using System;
using System.Configuration;
using System.Text;

namespace RKMC.Services.Common
{
    public class AppManager
    {
        #region VARIABLES

        private const string _CONNECTION_STRING_NAME = "Elite";

        #endregion


        protected string GetConnectionString()
        {
            return this.GetConnectionString(_CONNECTION_STRING_NAME);
        }
        protected string GetConnectionString(string Name)
        {
            return ConfigurationManager.ConnectionStrings[Name].ToString();
        }
    }
}