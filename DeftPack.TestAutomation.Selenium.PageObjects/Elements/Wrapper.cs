using DeftPack.TestAutomation.Selenium.PageObjects.Capabilities;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements
{
    public abstract class Wrapper : Element, IContainer
    {
        protected Wrapper(IWebElement proxyObject, IEnumerable<IElement> childs) : base(proxyObject)
        {
            ChildElements = childs;
        }

        public IEnumerable<IElement> ChildElements { get; private set; }

        public string GetText()
        {
            return string.Join(" ", ChildElements.OfType<ITextual>().Select(x => x.Text));
        }
    }
}
