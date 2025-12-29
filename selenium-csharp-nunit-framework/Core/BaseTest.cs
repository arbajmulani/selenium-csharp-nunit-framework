using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_csharp_nunit_framework.Core
{
    public class BaseTest
    {
        [SetUp]
        public void Setup()
        {
            DriverFactory.InitDriver();
        }

        [TearDown]
        public void TearDown()
        {
            DriverFactory.QuitDriver();
        }
    }
}
