using OpenQA.Selenium;
using System.Linq;

namespace DeftPack.TestAutomation.Selenium
{
    public static class WebDriverNavigationExtensions
    {
        public static void NavigateToUrl(this IWebDriver webDriver, string url)
        {
            webDriver.Navigate().GoToUrl(url);
            webDriver.Manage().Window.Maximize();
        }

        public static string SwitchToNewWindow(this IWebDriver webDriver)
        {
            var parentWindow = webDriver.CurrentWindowHandle;
            var handles = webDriver.WindowHandles;
            webDriver.SwitchTo().Window(handles.Last());
            return parentWindow;
        }

        public static void SwitchToWindow(this IWebDriver webDriver, string windowName)
        {
            webDriver.SwitchTo().Window(windowName);
        }
    }
}
