using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_csharp_nunit_framework.Utilities
{
    public class ConfigHelper
    {
        //ConfigHelper class having app setting related data
        private static IConfiguration _config;

        #region App Setting Helper

        static ConfigHelper()
        {
            _config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public static string BaseUrl =>_config["AppSettings:BaseUrl"];

        public static string Browser =>_config["AppSettings:Browser"];

        public static int Timeout =>int.Parse(_config["AppSettings:Timeout"]);

        public static string ScreenshotPath => _config["AppSettings:ScreenshotPath"];

        public static string Login_XLFile =>_config["ExcelFiles:XL_Login"];

        public static string Login_Sheet =>_config["ExcelFiles:SH_Login"];

        public static string GetJsonPath(string key)
        {
            return _config[$"JsonFiles:{key}"];
        }

        #endregion App Setting Helper
    }
}
