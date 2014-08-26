using System.Collections.Generic;

namespace DeftPack.TestAutomation.Selenium.HtmlElements.Capabilities
{
    public interface IContainer : IElement
    {
        IEnumerable<IElement> ChildElements { get; }
    }
}