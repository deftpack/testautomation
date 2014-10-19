using System;

namespace DeftPack.TestAutomation.Selenium
{
    /// <summary>
    /// Exception which is thrown when the browser is not supported or the binaries not found
    /// </summary>
    public class WebDriverNotFoundException : Exception
    {
        public WebDriverNotFoundException(string browser)
            : base(string.Format("Web Driver Not Found for {0}.", browser)) { }
    }
}
