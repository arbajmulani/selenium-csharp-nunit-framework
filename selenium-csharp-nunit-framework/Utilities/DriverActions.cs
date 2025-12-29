using OpenQA.Selenium;
using selenium_csharp_nunit_framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   

namespace selenium_csharp_nunit_framework.Utilities
{
    public class DriverActions
    {
        #region EnterText
        public static void EnterText( string componentName,By locator,string text,int timeout = 30)
        {
            IWebDriver driver = DriverFactory.Driver;

            try
            {
                // 1️⃣ WAIT
                IWebElement element = WaitHelper.WaitForElementVisible( driver,locator,timeout);

                // 2️⃣ SCROLL INTO VIEW
                ((IJavaScriptExecutor)driver)
                    .ExecuteScript("arguments[0].scrollIntoView(true);", element);

                // 3️⃣ HIGHLIGHT → YELLOW
                Highlight(element, "yellow");

                element.Clear();
                element.SendKeys(text);

                // 4️⃣ LOG SUCCESS
                Extensions.UpdateExcelTestReport(
                    componentName,
                    "EnterText",
                    locator.ToString(),
                    "Pass",
                    text,
                    "Text entered successfully"
                );
            }
            catch (Exception ex)
            {
                try
                {
                    IWebElement failedElement = driver.FindElement(locator);

                    // 🔴 RED highlight on failure
                    Highlight(failedElement, "red");
                }
                catch { }

                // 📸 SCREENSHOT ON FAILURE
                ScreenshotHelper.TakeScreenshot();

                Extensions.UpdateExcelTestReport(
                    componentName,
                    "EnterText",
                    locator.ToString(),
                    "Fail",
                    text,
                    ex.Message
                );

                // 🔥 THIS LINE IS MANDATORY
                throw;
            }
        }

        #endregion EnterText

        #region Click WebElement

        public static void ClickWebElement(string componentName,By locator,int timeout = 30)
        {
            IWebDriver driver = DriverFactory.Driver;

            try
            {
                // 1️⃣ WAIT
                IWebElement element = WaitHelper.WaitForElementClickable(driver, locator, timeout);

                // 2️⃣ SCROLL INTO VIEW
                ((IJavaScriptExecutor)driver)
                    .ExecuteScript("arguments[0].scrollIntoView(true);", element);

                // 3️⃣ HIGHLIGHT → YELLOW
                Highlight(element, "yellow");

                element.Click();

                // 4️⃣ LOG SUCCESS
                Extensions.UpdateExcelTestReport(
                    componentName,
                    "Click",
                    locator.ToString(),
                    "Pass",
                    "",
                    "Element clicked successfully"
                );
            }
            catch (Exception ex)
            {
                try
                {
                    IWebElement failedElement = driver.FindElement(locator);

                    // 🔴 RED highlight on failure
                    Highlight(failedElement, "red");
                }
                catch { }

                // 📸 SCREENSHOT ON FAILURE
                ScreenshotHelper.TakeScreenshot();

                Extensions.UpdateExcelTestReport(
                    componentName,
                    "Click",
                    locator.ToString(),
                    "Fail",
                    "",
                    ex.Message
                );

                // 🔥 REQUIRED so test FAILS
                throw;
            }
        }


        #endregion Click WebElement

        #region Verify Text

        public static void VerifyText(string componentName,By locator,string expectedText,int timeout = 30)
        {
            IWebDriver driver = DriverFactory.Driver;

            try
            {
                // 1️⃣ WAIT
                IWebElement element = WaitHelper.WaitForElementVisible(driver, locator, timeout);


                // 2️⃣ SCROLL INTO VIEW
                ((IJavaScriptExecutor)driver)
                    .ExecuteScript("arguments[0].scrollIntoView(true);", element);

                // 3️⃣ HIGHLIGHT → YELLOW (before verify)
                Highlight(element, "yellow");

                string actualText = element.Text.Trim();

                if (!actualText.Equals(expectedText.Trim()))
                {
                    // 🔴 RED highlight for mismatch
                    Highlight(element, "red");

                    // 📸 Screenshot on failure
                    ScreenshotHelper.TakeScreenshot();

                    Extensions.UpdateExcelTestReport(
                        componentName,
                        "VerifyText",
                        locator.ToString(),
                        "Fail",
                        $"Expected: {expectedText} | Actual: {actualText}",
                        "Text mismatch"
                    );

                    // 🔥 Force test failure
                    throw new Exception(
                        $"Text verification failed. Expected [{expectedText}] but found [{actualText}]"
                    );
                }

                Extensions.UpdateExcelTestReport(
                    componentName,
                    "VerifyText",
                    locator.ToString(),
                    "Pass",
                    expectedText,
                    "Text verified successfully"
                );
            }
            catch
            {
                throw; // 🔥 Mandatory
            }
        }


        #endregion Verify Text

        #region Verify Contains Text

        public static void VerifyTextContains(string componentName,By locator,string expectedPartialText,int timeout = 30)
        {
            IWebDriver driver = DriverFactory.Driver;

            try
            {
                // 1️⃣ WAIT
                IWebElement element = WaitHelper.WaitForElementVisible(
                    driver,
                    locator,
                    timeout
                );

                // 2️⃣ SCROLL INTO VIEW
                ((IJavaScriptExecutor)driver)
                    .ExecuteScript("arguments[0].scrollIntoView(true);", element);

                // 3️⃣ HIGHLIGHT → YELLOW
                Highlight(element, "yellow");

                string actualText = element.Text.Trim();

                if (!actualText.Contains(expectedPartialText.Trim()))
                {
                    // 🔴 RED highlight on failure
                    Highlight(element, "red");

                    // 📸 Screenshot on failure
                    ScreenshotHelper.TakeScreenshot();

                    Extensions.UpdateExcelTestReport(
                        componentName,
                        "VerifyTextContains",
                        locator.ToString(),
                        "Fail",
                        $"Expected contains: {expectedPartialText} | Actual: {actualText}",
                        "Partial text not found"
                    );

                    // 🔥 Force test failure
                    throw new Exception(
                        $"Text verification failed. Expected text to contain [{expectedPartialText}] but found [{actualText}]"
                    );
                }

                Extensions.UpdateExcelTestReport(
                    componentName,
                    "VerifyTextContains",
                    locator.ToString(),
                    "Pass",
                    expectedPartialText,
                    "Partial text verified successfully"
                );
            }
            catch
            {
                throw; // 🔥 mandatory
            }
        }


        #endregion Verify Contains Text

        #region Is Element Present

        public static void IsElementPresent(string componentName,By locator,int timeout = 30)
        {
            IWebDriver driver = DriverFactory.Driver;

            try
            {
                // 1️⃣ WAIT FOR VISIBILITY
                IWebElement element = WaitHelper.WaitForElementVisible(
                    driver,
                    locator,
                    timeout
                );

                // 2️⃣ SCROLL INTO VIEW
                ((IJavaScriptExecutor)driver)
                    .ExecuteScript("arguments[0].scrollIntoView(true);", element);

                // 3️⃣ HIGHLIGHT → YELLOW (STANDARD)
                Highlight(element, "yellow");

                // 4️⃣ LOG SUCCESS
                Extensions.UpdateExcelTestReport(
                    componentName,
                    "IsElementPresent",
                    locator.ToString(),
                    "Pass",
                    "N/A",
                    "Element is present on UI"
                );
            }
            catch (Exception ex)
            {
                // 📸 SCREENSHOT ONLY ON FAILURE
                ScreenshotHelper.TakeScreenshot();

                Extensions.UpdateExcelTestReport(
                    componentName,
                    "IsElementPresent",
                    locator.ToString(),
                    "Fail",
                    "N/A",
                    "Element not present on UI - " + ex.Message
                );

                // 🔥 FAIL TEST
                throw;
            }
        }


        #endregion Click WebElement


        #region HELPER METHODS
        private static void Highlight(IWebElement element, string color)
        {
            IJavaScriptExecutor js =
                (IJavaScriptExecutor)DriverFactory.Driver;

            js.ExecuteScript(
                "arguments[0].style.border='3px solid " + color + "'",
                element);
        }

        #endregion HELPER METHODS



    }
}
