using selenium_csharp_nunit_framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_csharp_nunit_framework.Pages
{
    public class NavigateToLogin
    {
        public static LoginPage loginPage => new(DriverFactory.Driver);
    }
}
