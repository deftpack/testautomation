using System.Collections.Generic;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements
{
    public interface ISelectable : IElement
    {
        IEnumerable<string> Options { get; }
        string Value { get; set; }
        void Select(int index);
    }
}