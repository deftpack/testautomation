using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements
{
    /// <summary>
    /// Looks up element types
    /// </summary>
    public class ElementTypeFinder : IElementTypeFinder
    {
        public static readonly IEnumerable<Type> ElementTypes;

        static ElementTypeFinder()
        {
            ElementTypes = AppDomain.CurrentDomain.GetAssemblies()
                        .SelectMany(asm => asm.GetTypes().Where(t => t.IsSubclassOf(typeof(Element))));
        }

        /// <summary>
        /// Find a matching element type for a web element
        /// </summary>
        /// <param name="webElement">Web element to inspect</param>
        /// <returns>Element Type</returns>
        public Type Find(IWebElement webElement)
        {
            return ElementTypes.FirstOrDefault(t =>
                    t.GetCustomAttributes<HtmlTagAttribute>().Any(a => a.TagName == webElement.TagName) ||
                    (webElement.TagName == "input" && t.GetCustomAttributes<HtmlInputAttribute>()
                         .Any(a => webElement.GetAttribute("type") == a.InputType.ToString().ToLower())));
        }
    }
}
