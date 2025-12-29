using DocumentFormat.OpenXml.Spreadsheet;
using OpenQA.Selenium;
using selenium_csharp_nunit_framework.Models;
using selenium_csharp_nunit_framework.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_csharp_nunit_framework.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }


        private By usernameField = By.Id("username");
        private By passwordField = By.Id("password");
        private By loginButton = By.CssSelector("button[type='submit']");
        private By txt_YouLoggedInSecureArea = By.Id("flash");
        private By txt_WelcomeToSecureArea= By.XPath("//*[@id=\"content\"]/div/h4");
        private By btnLogout = By.XPath("//*[@id=\"content\"]/div/a");

        // Actions

        public void Login(string componentName, string username, string password)
        {
            DriverActions.EnterText(componentName, usernameField, username);
            DriverActions.EnterText(componentName, passwordField, password);
            DriverActions.ClickWebElement(componentName, loginButton);
        }

        public void  VerifyAppLaunchData(string componentName, LoginModel model)
        {          
            DriverActions.VerifyTextContains(componentName, txt_YouLoggedInSecureArea, model.TXT_YouLoggedInSecureArea);
            Thread.Sleep(2000);
            DriverActions.VerifyText(componentName, txt_WelcomeToSecureArea, model.TXT_WelcomeToSecureArea);
            Thread.Sleep(2000);
            DriverActions.IsElementPresent(componentName, btnLogout);

        }

    }
}
