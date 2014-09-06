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
                    {
                        var profile = new FirefoxProfile();
                        if (_configuration != null && !string.IsNullOrWhiteSpace(_configuration.UserAgent))
                        {
                            profile.SetPreference("general.useragent.override",
                                _configuration.UserAgent);
                        }
                        return new FirefoxDriver();
                    }
                case Browser.InternetExplorer:
                    {
                        var driverService = InternetExplorerDriverService.CreateDefaultService();
                        driverService.HideCommandPromptWindow = true;
                        return new InternetExplorerDriver(driverService, new InternetExplorerOptions());
                    }
                case Browser.Chrome:
                    {
                        var driverService = ChromeDriverService.CreateDefaultService(driverLocation);
                        driverService.HideCommandPromptWindow = true;
                        return new ChromeDriver(driverService, new ChromeOptions());
                    }
                case Browser.Safari:
                    {
                        return new SafariDriver();
                    }
                case Browser.PhantomJS:
                    {
                        var driverService = PhantomJSDriverService.CreateDefaultService(driverLocation);
                        driverService.HideCommandPromptWindow = true;

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
