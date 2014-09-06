using System.Collections.Generic;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Capabilities
{
    public interface IContainer : IElement
    {
        IEnumerable<IElement> ChildElements { get; }
    }
}