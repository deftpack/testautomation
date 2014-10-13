using System.Collections.Generic;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements
{
    public interface IElement
    {
        string TagName { get; }
        string Id { get; }
        IEnumerable<string> Classes { get; }
        bool IsVisible { get; }
    }
}