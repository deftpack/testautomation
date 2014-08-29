using DeftPack.TestAutomation.Selenium.PageObjects.Elements;
using DeftPack.TestAutomation.Selenium.PageObjects.Elements.Table;
using OpenQA.Selenium;
using System;
using System.Linq;

namespace DeftPack.TestAutomation.Selenium.PageObjects
{
    internal class ElementFactory
    {
        public TElement Create<TElement>(IWebDriver webDriver, string selector) where TElement : Element
        {
            var elementType = typeof (TElement);
            var webElement = webDriver.jQueryElement(selector);


            if (elementType == typeof (TableRow))
            {
                return (TElement) CreateTableRow(webElement);
            }

            if (elementType == typeof (TableBody) ||
                elementType == typeof (TableHeader) ||
                elementType == typeof (TableFooter))
            {
                return CreateTablePart<TElement>(webElement);
            }

            if (elementType == typeof (Table))
            {
                var header = CreateTablePart<TableHeader>(webElement.FindElement(By.CssSelector("thead")));
                var body = CreateTablePart<TableBody>(webElement.FindElement(By.CssSelector("tbody")) ?? webElement);
                var footer = CreateTablePart<TableHeader>(webElement.FindElement(By.CssSelector("tfoot")));

                return (TElement) Activator.CreateInstance(typeof (TElement), webElement, body, header, footer);
            }

            if (!elementType.IsSubclassOf(typeof (Wrapper)))
            {
                return (TElement) Activator.CreateInstance(typeof (TElement), webElement);
            }

            return CreateWrapperElement<TElement>(webElement);
        }

        private TElement CreateWrapperElement<TElement>(IWebElement webElement) where TElement : Element
        {
            var childElements = webElement.FindElements(By.CssSelector("*"));
            return (TElement) Activator.CreateInstance(typeof (TElement), webElement, childElements);
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
                    Activator.CreateInstance(typeof (TElement), webElement,
                        cellElements.Select(x => (TableRow) CreateTableRow(x)));
        }
    }
}
