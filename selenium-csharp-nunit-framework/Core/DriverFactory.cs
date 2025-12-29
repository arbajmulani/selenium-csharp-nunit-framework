using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using selenium_csharp_nunit_framework.Utilities;

namespace selenium_csharp_nunit_framework.Core
{
    public class DriverFactory
    {
        public static IWebDriver Driver;

        public static void InitDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
        }

        public static void QuitDriver()
        {
            Driver?.Quit();
        }
    }
}
