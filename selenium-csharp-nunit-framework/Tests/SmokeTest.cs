using selenium_csharp_nunit_framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_csharp_nunit_framework.Tests
{
    public class SmokeTest : BaseTest
    {
        [Test]
        public void OpenGoogleTest() 
        {
            //Assert.Pass("Framework setup successful");
            DriverFactory.Driver.Navigate().GoToUrl("https://www.google.com");
            Assert.That(DriverFactory.Driver.Title,Is.EqualTo("Google"));
        }
    }
}
