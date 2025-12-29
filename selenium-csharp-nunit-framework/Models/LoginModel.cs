using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_csharp_nunit_framework.Models
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string TXT_YouLoggedInSecureArea { get; set; }
        public string TXT_WelcomeToSecureArea { get; set; }
    }
}
