using Moq;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Linq;

namespace DeftPack.TestAutomation.Selenium.PageObjects.UnitTests.Factories
{
    internal class WebElementMockFactory
    {
        internal IWebElement Table(IWebElement body, IWebElement header, IWebElement footer)
        {
            var element = new Mock<IWebElement>();
            element.SetupGet(x => x.TagName).Returns("table");
            element.SetupGet(x => x.Text).Returns(string.Empty);
            element.Setup(x => x.FindElement(By.CssSelector("tbody"))).Returns<By>(x => body);
            element.Setup(x => x.FindElement(By.CssSelector("thead"))).Returns<By>(x => header);
            element.Setup(x => x.FindElement(By.CssSelector("tfoot"))).Returns<By>(x => footer);
            return element.Object;
        }

        internal IWebElement Element(string tagName)
        {
            var element = new Mock<IWebElement>();
            element.SetupGet(x => x.TagName).Returns(tagName);
            element.SetupGet(x => x.Text).Returns(string.Empty);
            element.Setup(x => x.GetAttribute("type")).Returns<string>(x => string.Empty);
            element.Setup(x => x.FindElements(It.IsAny<By>()))
                .Returns<By>(x => new ReadOnlyCollection<IWebElement>(new IWebElement[0]));
            return element.Object;
        }

        internal IWebElement Input(string typeAttribute)
        {
            var element = new Mock<IWebElement>();
            element.SetupGet(x => x.TagName).Returns("input");
            element.SetupGet(x => x.Text).Returns(string.Empty);
            element.Setup(x => x.GetAttribute("type")).Returns<string>(x => typeAttribute);
            element.Setup(x => x.FindElements(It.IsAny<By>()))
                .Returns<By>(x => new ReadOnlyCollection<IWebElement>(new IWebElement[0]));
            return element.Object;
        }

        internal IWebElement TextElement(string tagName, string text)
        {
            var element = new Mock<IWebElement>();
            element.SetupGet(x => x.TagName).Returns(tagName);
            element.SetupGet(x => x.Text).Returns(text);
            element.Setup(x => x.GetAttribute("type")).Returns<string>(x => string.Empty);
            element.Setup(x => x.FindElements(It.IsAny<By>()))
                .Returns<By>(x => new ReadOnlyCollection<IWebElement>(new IWebElement[0]));
            return element.Object;
        }

        internal IWebElement Wrapper(string tagName, params IWebElement[] childElements)
        {
            var element = new Mock<IWebElement>();
            element.SetupGet(x => x.TagName).Returns(tagName);
            element.SetupGet(x => x.Text).Returns(string.Empty);
            element.Setup(x => x.GetAttribute("type")).Returns<string>(x => string.Empty);
            element.Setup(x => x.FindElements(It.IsAny<By>()))
                .Returns<By>(x => new ReadOnlyCollection<IWebElement>(childElements.ToList()));
            return element.Object;
        }
    }
}