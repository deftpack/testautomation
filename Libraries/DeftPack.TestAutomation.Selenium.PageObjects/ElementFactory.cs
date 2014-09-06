using DeftPack.TestAutomation.Selenium.PageObjects.Elements;
using DeftPack.TestAutomation.Selenium.PageObjects.Elements.Table;
using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;
using DeftPack.TestAutomation.Selenium.PageObjects.WebDriverExtensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DeftPack.TestAutomation.Selenium.PageObjects
{
    internal class ElementFactory
    {
        private static readonly IEnumerable<Type> ElementTypes;

        static ElementFactory()
        {
            ElementTypes = AppDomain.CurrentDomain.GetAssemblies()
                        .SelectMany(asm => asm.GetTypes().Where(t => t.IsSubclassOf(typeof(Element))));
        }

        public TElement Create<TElement>(IWebDriver webDriver, string selector) where TElement : Element
        {
            var webElement = webDriver.jQueryElement(selector);
            return CreateFor<TElement>(webElement);
        }

        public TElement CreateFor<TElement>(IWebElement webElement) where TElement : Element
        {
            var elementType = typeof(TElement);

            if (webElement == null)
            {
                return null;
            }
            else if (elementType == typeof(TableRow))
            {
                return (TElement)CreateTableRow(webElement);
            }
            else if (elementType == typeof(TableBody) || elementType == typeof(TableHeader) || elementType == typeof(TableFooter))
            {
                return CreateTablePart<TElement>(webElement);
            }
            else if (elementType == typeof(Table))
            {
                var header = CreateTablePart<TableHeader>(webElement.FindElement(By.CssSelector("thead")));
                var body = CreateTablePart<TableBody>(webElement.FindElement(By.CssSelector("tbody")) ?? webElement);
                var footer = CreateTablePart<TableHeader>(webElement.FindElement(By.CssSelector("tfoot")));

                return (TElement)Activator.CreateInstance(typeof(TElement), webElement, body, header, footer);
            }
            else if (!elementType.IsSubclassOf(typeof(Wrapper)))
            {
                return (TElement)Activator.CreateInstance(typeof(TElement), webElement);
            }

            return CreateWrapperElement<TElement>(webElement);
        }

        private TElement CreateWrapperElement<TElement>(IWebElement webElement) where TElement : Element
        {
            var childElements =
                webElement.FindElements(By.CssSelector("*")).Select(x =>
                {
                    var elementType = FindElementTypeForWebElement(x);
                    return elementType == null
                        ? null
                        : (IElement)(typeof(ElementFactory)
                            .GetMethod("CreateFor")
                            .MakeGenericMethod(elementType)
                            .Invoke(this, new object[] { x }));
                }).Where(x => x != null).ToList();

            return
                (TElement)
                    Activator.CreateInstance(typeof(TElement), webElement,
                        childElements.Any() ? childElements : null);
        }

        private object CreateTableRow(IWebElement webElement)
        {
            var cellElements = webElement.FindElements(By.CssSelector("td, th"));
            return new TableRow(webElement, cellElements.Select(CreateWrapperElement<TableCell>));
        }

        private TElement CreateTablePart<TElement>(IWebElement webElement) where TElement : Element
        {
            var cellElements = webElement.FindElements(By.CssSelector("tr"));
            return
                (TElement)
                    Activator.CreateInstance(typeof(TElement), webElement,
                        cellElements.Select(x => (TableRow)CreateTableRow(x)));
        }

        private Type FindElementTypeForWebElement(IWebElement webElement)
        {
            return
                ElementTypes.FirstOrDefault(t =>
                    t.GetCustomAttributes<HtmlTagAttribute>().Any(a => a.TagName == webElement.TagName) ||
                    (webElement.TagName == "input" &&
                     t.GetCustomAttributes<HtmlInputAttribute>()
                         .Any(a => webElement.GetAttribute("type") == a.InputType.ToString().ToLower())));
        }
    }
}
