using System.Collections.Generic;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements
{
    public interface IContainer : IElement
    {
        IEnumerable<IElement> ChildElements { get; }
    }
}