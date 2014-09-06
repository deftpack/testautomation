using System.Collections.Generic;

namespace DeftPack.TestAutomation.Selenium.PageObjects
{
    public interface IElement
    {
        string Id { get; }
        IEnumerable<string> Classes { get; }
        bool IsVisible { get; }
    }
}