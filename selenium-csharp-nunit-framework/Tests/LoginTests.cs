using selenium_csharp_nunit_framework.Core;
using selenium_csharp_nunit_framework.Models;
using selenium_csharp_nunit_framework.Pages;
using selenium_csharp_nunit_framework.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_csharp_nunit_framework.Tests
{
    public class LoginTests : BaseTest
    {


        [Test]
        public void ValidLoginTest_UsingJson()
        {
            LoginModel model = DataSources.GetValidLogin();

            DriverFactory.Driver.Navigate().GoToUrl(ConfigHelper.BaseUrl);
            string componentName = nameof(ValidLoginTest_UsingJson);
            Pages.NavigateToLogin.loginPage.Login(componentName, model.Username, model.Password);
            Pages.NavigateToLogin.loginPage.VerifyAppLaunchData(componentName, model);

        }

        [Test]
        public void ValidLoginTest_UsingExcel()
        {
            LoginModel model = ExcelUtility.ReadSingleRow<LoginModel>(ConfigHelper.Login_XLFile, ConfigHelper.Login_Sheet);

            DriverFactory.Driver.Navigate().GoToUrl(ConfigHelper.BaseUrl);

            LoginPage loginPage = new LoginPage(DriverFactory.Driver);
            string componentName = nameof(ValidLoginTest_UsingJson);
            Pages.NavigateToLogin.loginPage.Login(componentName, model.Username, model.Password);


            Assert.That(
                DriverFactory.Driver.PageSource.Contains(model.TXT_YouLoggedInSecureArea),
                Is.True);
        }

        
    }
}
