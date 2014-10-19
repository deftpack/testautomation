using OpenQA.Selenium;
using System.Linq;

namespace DeftPack.TestAutomation.Selenium
{
    public static class WebDriverNavigationExtensions
    {
        /// <summary>
        /// Navigate to the given URL, while maximizing the window
        /// </summary>
        /// <param name="webDriver">The web driver to be used</param>
        /// <param name="url">Web address to navigate to</param>
        public static void NavigateToUrl(this IWebDriver webDriver, string url)
        {
            webDriver.Navigate().GoToUrl(url);
            webDriver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Switch to the window thats been opened last
        /// </summary>
        /// <param name="webDriver">The web driver to be used</param>
        /// <returns>The name of the original window so it could be referenced later</returns>
        public static string SwitchToNewWindow(this IWebDriver webDriver)
        {
            var parentWindow = webDriver.CurrentWindowHandle;
            var handles = webDriver.WindowHandles;
            webDriver.SwitchTo().Window(handles.Last());
            return parentWindow;
        }

        /// <summary>
        /// Switch to the given window
        /// </summary>
        /// <param name="webDriver">The web driver to be used<</param>
        /// <param name="windowName">Name of the window to switch to</param>
        public static void SwitchToWindow(this IWebDriver webDriver, string windowName)
        {
            webDriver.SwitchTo().Window(windowName);
        }
    }
}
