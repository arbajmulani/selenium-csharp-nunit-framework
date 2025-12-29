using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_csharp_nunit_framework.Utilities
{
    public class Logger
    {
        //Logger class creted for log the error
        public static NLog.Logger Log => LogManager.GetLogger(TestContext.CurrentContext.Test.Name);
    }
}
