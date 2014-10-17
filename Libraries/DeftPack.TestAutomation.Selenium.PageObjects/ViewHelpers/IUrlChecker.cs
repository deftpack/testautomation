using System;

namespace DeftPack.TestAutomation.Selenium.PageObjects.ViewHelpers
{
    public interface IUrlChecker
    {
        bool MatchUrl(params string[] urlParts);
        bool MatchUrl<TPage>() where TPage : View;
        bool MatchUrl(Type pageType);
    }
}