using System.Collections.Generic;

namespace DeftPack.TestAutomation.Selenium.PageObjects.ViewHelpers
{
    public interface IJavaScriptHandler
    {
        IEnumerable<string> ErrorMessages { get; }
        bool IsPageReady { get; }
    }
}