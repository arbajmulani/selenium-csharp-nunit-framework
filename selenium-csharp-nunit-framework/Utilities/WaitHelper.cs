using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_csharp_nunit_framework.Utilities
{
    public class WaitHelper
    {
        private static WebDriverWait GetWait(IWebDriver driver, int? timeout = null)
        {
            return new WebDriverWait(
                driver,
                TimeSpan.FromSeconds(timeout ?? ConfigHelper.Timeout));
        }

        public static IWebElement WaitForElementVisible(
            IWebDriver driver,
            By locator,
            int? timeout = null)
        {
            return GetWait(driver, timeout)
                .Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static IWebElement WaitForElementClickable(
           IWebDriver driver,
           By locator,
           int? timeout = null)
        {
            return GetWait(driver, timeout)
                .Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public static bool WaitForElementClickable(
    IWebDriver driver,
    IWebElement element,
    int timeout = 30)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(
                    driver,
                    TimeSpan.FromSeconds(timeout)
                );

                return wait.Until(d =>
                {
                    return element.Displayed && element.Enabled;
                });
            }
            catch
            {
                return false;
            }
        }


        public static bool WaitForTextPresent(
            IWebDriver driver,
            By locator,
            string text,
            int? timeout = null)
        {
            return GetWait(driver, timeout)
                .Until(ExpectedConditions.TextToBePresentInElementLocated(locator, text));
        }

        public static bool WaitForUrlContains(
            IWebDriver driver,
            string partialUrl,
            int? timeout = null)
        {
            return GetWait(driver, timeout)
                .Until(ExpectedConditions.UrlContains(partialUrl));
        }


    }
}
