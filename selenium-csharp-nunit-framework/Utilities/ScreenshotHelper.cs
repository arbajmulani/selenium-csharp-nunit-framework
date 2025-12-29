using OpenQA.Selenium;
using selenium_csharp_nunit_framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_csharp_nunit_framework.Utilities
{
    public class ScreenshotHelper
    {
        public static void TakeScreenshot()
        {
            try
            {
                IWebDriver driver = DriverFactory.Driver;

                string basePath = ConfigHelper.ScreenshotPath; // C:\Temp\
                string folderName = "Screenshots_" + DateTime.Now.ToString("yyyy_MM_dd");
                string directoryPath = Path.Combine(basePath, folderName);

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                string tcName = TestContext.CurrentContext.Test.Name
                    .Replace("\"", "")
                    .Replace(";", "-")
                    .Replace("/", "_");

                string filePath = Path.Combine(
                    directoryPath,
                    $"{tcName}_{DateTime.Now:yyyy_MM_dd_HH_mm_ss}.png"
                );

                ITakesScreenshot screenshotDriver = (ITakesScreenshot)driver;
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                screenshot.SaveAsFile(filePath);

                Console.WriteLine($"Screenshot saved at: {filePath}");
                Logger.Log.Info($"Screenshot saved at: {filePath}");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Screenshot capture failed: " + ex.Message);
            }
        }
    }
}
