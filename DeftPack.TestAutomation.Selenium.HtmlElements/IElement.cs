using System.Collections.Generic;

namespace DeftPack.TestAutomation.Selenium.HtmlElements
{
    public interface IElement
    {
        string Id { get; }
        IEnumerable<string> Classes { get; }
        bool IsVisible { get; }
    }
}