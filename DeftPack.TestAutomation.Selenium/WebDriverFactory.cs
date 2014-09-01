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
            var driverLocation = _configuration.DriverLocation;

            switch (browser)
            {
                case Browser.Firefox:
                    return new FirefoxDriver();
                case Browser.InternetExplorer:
                    return new InternetExplorerDriver(driverLocation);
                case Browser.Chrome:
                    return new ChromeDriver(driverLocation);
                case Browser.Safari:
                    return new SafariDriver();
                case Browser.PhantomJS:
                    {
                        var driverService = PhantomJSDriverService.CreateDefaultService(driverLocation);
                        var driverOptions = new PhantomJSOptions();

                        if (_configuration != null && _configuration.DebuggingPort > 0)
                        {
                            driverService.AddArgument(string.Format("--remote-debugger-port={0}",
                                _configuration.DebuggingPort));
                        }

                        if (_configuration != null && !string.IsNullOrWhiteSpace(_configuration.UserAgent))
                        {
                            driverOptions.AddAdditionalCapability("phantomjs.page.settings.userAgent",
                                _configuration.UserAgent);
                        }

                        return new PhantomJSDriver(driverService, driverOptions);
                    }
            }

            throw new WebDriverNotFoundException(browser.ToString());
        }

        public IWebDriver Default
        {
            get { return Create(_configuration.DefaultBrowser); }
        }
    }
}
