using selenium_csharp_nunit_framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace selenium_csharp_nunit_framework.Utilities
{
    public class DataSources
    {
        //DataSources class created for data fetching from respective file (Currently created only for json file not excel file)
        public static LoginModel GetValidLogin()
        {
            var data =
                ReadJson<Dictionary<string, LoginModel>>(
                    ConfigHelper.GetJsonPath("LoginData"));

            return data["ValidLogin"];
        }

        public static T ReadJson<T>(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(json);
        }

    }
}
