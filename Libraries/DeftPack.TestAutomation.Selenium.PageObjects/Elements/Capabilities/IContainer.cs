using System.Collections.Generic;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements
{
    internal interface IContainer : IElement
    {
        IEnumerable<IElement> ChildElements { get; }
    }
}