using DeftPack.TestAutomation.Selenium.PageObjects.Elements.Table;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements
{
    public class ElementFactory
    {
        private readonly IElementTypeFinder _typeFinder = new ElementTypeFinder();
        private readonly IDictionary<Type, string> _tableChildSelectors = new Dictionary<Type, string>
        {
            {typeof (Table.Table), "thead, tbody, tfoot"},
            {typeof (TableRow), "td, th"},
            {typeof (TableHeader), "tr"},
            {typeof (TableBody), "tr"},
            {typeof (TableFooter), "tr"},
        };

        public TElement Create<TElement>(IWebElement webElement) where TElement : Element
        {
            string selector = null;
            var elementType = typeof(TElement);
            if (webElement == null) return null;

            if (_tableChildSelectors.ContainsKey(elementType)) selector = _tableChildSelectors[elementType];
            else if (elementType.IsSubclassOf(typeof(Wrapper))) selector = "*";

            return CreateElement<TElement>(webElement, selector);
        }

        private TElement CreateElement<TElement>(IWebElement webElement, string childCssSelector = null)
        {
            var childElements = string.IsNullOrWhiteSpace(childCssSelector) ? null : webElement
                .FindElements(By.CssSelector(childCssSelector)).Select(element =>
                {
                    var elementType = _typeFinder.Find(element);
                    return elementType == null ? null : (IElement)(typeof(ElementFactory).GetMethod("Create")
                            .MakeGenericMethod(elementType).Invoke(this, new object[] { element }));
                }).Where(element => element != null).ToList();

            var parameters = childElements == null ? null : childElements.Any() ? childElements : null;
            return (TElement)Activator.CreateInstance(typeof(TElement), webElement, parameters);
        }
    }
}
