using DeftPack.TestAutomation.Selenium.PageObjects.Elements.Capabilities;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements
{
    public abstract class Wrapper : Element, IContainer
    {
        protected Wrapper(IWebElement proxyObject, IEnumerable<IElement> childs)
            : base(proxyObject)
        {
            ChildElements = childs;
        }

        public IEnumerable<IElement> ChildElements { get; private set; }

        public string GetText()
        {
            var texts = new List<string> { ProxyObject.Text };
            texts.AddRange(ChildElements.OfType<ITextual>().Select(x => x.Text));
            texts = texts.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
            return texts.Any() ? string.Join(string.Empty, texts) : string.Empty;
        }
    }
}
