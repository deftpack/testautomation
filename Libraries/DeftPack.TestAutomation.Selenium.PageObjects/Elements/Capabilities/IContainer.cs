using System.Collections.Generic;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements.Capabilities
{
    public interface IContainer : IElement
    {
        IEnumerable<IElement> ChildElements { get; }
    }
}