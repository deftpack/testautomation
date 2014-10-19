using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Safari;

namespace DeftPack.TestAutomation.Selenium
{
    /// <summary>
    /// Factory class for Selenium Web Drivers
    /// </summary>
    public class WebDriverFactory
    {
        private readonly WebDriverConfiguration _configuration = WebDriverConfiguration.Config;

        /// <summary>
        /// Creating a new web driver instance
        /// </summary>
        /// <param name="browser">What browser should be used</param>
        /// <returns>Web Driver</returns>
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

                        if (_configuration != null)
                        {
                            if (_configuration.Debugging != null)
                            {
                                if (!string.IsNullOrWhiteSpace(_configuration.Debugging.LogFileFullPath))
                                {
                                    driverService.LogFile = _configuration.Debugging.LogFileFullPath;
                                }

                                if (_configuration.Debugging.Port > 0)
                                {
                                    driverService.AddArgument(string.Format("--remote-debugger-port={0}",
                                        _configuration.Debugging.Port));
                                }
                            }

                            if (!string.IsNullOrWhiteSpace(_configuration.UserAgent))
                            {
                                driverOptions.AddAdditionalCapability("phantomjs.page.settings.userAgent",
                                    _configuration.UserAgent);
                            }
                        }

                        return new PhantomJSDriver(driverService, driverOptions);
                    }
            }

            throw new WebDriverNotFoundException(browser.ToString());
        }

        /// <summary>
        /// Returns a web driver instance with the default browser
        /// </summary>
        public IWebDriver Default
        {
            get { return Create(_configuration.DefaultBrowser); }
        }
    }
}
