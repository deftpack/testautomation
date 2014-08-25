using OpenQA.Selenium;

namespace DeftPack.TestAutomation.Functional
{
    public abstract class Page
    {
        protected readonly IWebDriver WebDriver;

        protected Page(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }
    }
}
