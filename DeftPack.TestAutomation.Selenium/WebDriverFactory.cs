using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Safari;

namespace DeftPack.TestAutomation.Selenium
{
    public class WebDriverFactory
    {
        private readonly WebDriverConfiguration _configuration = WebDriverConfiguration.Config;

        public IWebDriver Create(Browser browser)
        {
            switch (browser)
            {
                case Browser.Firefox:
                    return new FirefoxDriver();
                case Browser.InternetExplorer:
                    return new InternetExplorerDriver(_configuration.DriverLocation);
                case Browser.Chrome:
                    return new ChromeDriver(_configuration.DriverLocation);
                case Browser.Safari:
                    return new SafariDriver();
                case Browser.PhantomJS:
                    return new PhantomJSDriver(_configuration.DriverLocation);
            }

            throw new WebDriverNotFoundException(browser.ToString());
        }

        public IWebDriver Default
        {
            get { return Create(_configuration.DefaultBrowser); }
        }
    }
}
