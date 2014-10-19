using OpenQA.Selenium;
using System;
using System.Linq;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements
{
    /// <summary>
    /// Create elements from the web elements
    /// </summary>
    public class ElementFactory : IElementFactory
    {
        private readonly IElementTypeFinder _typeFinder;

        public ElementFactory(IElementTypeFinder typeFinder)
        {
            _typeFinder = typeFinder;
        }

        /// <summary>
        /// Create element with the given type
        /// </summary>
        /// <typeparam name="TElement">Type of the element to be created</typeparam>
        /// <param name="webElement">The original web element which going to be wrapped</param>
        /// <returns>Instance of an element</returns>
        public TElement Create<TElement>(IWebElement webElement) where TElement : Element
        {
            if (webElement == null) return null;
            var elementType = typeof(TElement);

            if (elementType == typeof(Table))
                return (TElement)CreateTable(webElement);
            if (elementType == typeof(TableRow))
                return CreateWrapper<TElement, TableCell>(webElement, "td, th");
            if (new[] { typeof(TableHeader), typeof(TableBody), typeof(TableFooter) }.Contains(elementType))
                return CreateWrapper<TElement, TableRow>(webElement, "tr");

            return elementType.IsSubclassOf(typeof(Wrapper)) ?
                CreateWrapper<TElement, IElement>(webElement, "*") :
                (TElement)Activator.CreateInstance(typeof(TElement), webElement);
        }

        private TElement CreateWrapper<TElement, TChild>(IWebElement webElement, string cssSelector) where TChild : class
        {
            var childElements = webElement.FindElements(By.CssSelector(cssSelector))
                .Select(CreateChildElement<TChild>).Where(element => element != null).ToList();
            return (TElement)Activator.CreateInstance(typeof(TElement), webElement, childElements);
        }

        private TElement CreateChildElement<TElement>(IWebElement element) where TElement : class
        {
            var elementType = _typeFinder.Find(element);
            return elementType == null ? null : (TElement)(GetType().GetMethod("Create")
                    .MakeGenericMethod(elementType).Invoke(this, new object[] { element }));
        }
        private object CreateTable(IWebElement webElement)
        {
            return new Table(webElement,
                Create<TableBody>(webElement.FindElement(By.CssSelector("tbody"))),
                Create<TableHeader>(webElement.FindElement(By.CssSelector("thead"))),
                Create<TableFooter>(webElement.FindElement(By.CssSelector("tfoot"))));
        }
    }
}
