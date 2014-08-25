using System;

namespace DeftPack.TestAutomation.Selenium
{
    public class WebDriverNotFoundException : Exception
    {
        public WebDriverNotFoundException(string browser) 
            : base(string.Format("Web Driver Not Found for {0}.", browser)) { }
    }
}
