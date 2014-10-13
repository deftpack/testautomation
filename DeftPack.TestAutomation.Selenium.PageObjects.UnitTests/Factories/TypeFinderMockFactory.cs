using DeftPack.TestAutomation.Selenium.PageObjects.Elements;
using Moq;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace DeftPack.TestAutomation.Selenium.PageObjects.UnitTests.Factories
{
    internal class TypeFinderMockFactory
    {
        internal IElementTypeFinder Mock(IEnumerable<KeyValuePair<string, Type>> tagTypes = null,
            IEnumerable<KeyValuePair<string, Type>> inputTypes = null)
        {
            var typeFinder = new Mock<IElementTypeFinder>();
            if (tagTypes != null)
            {
                foreach (var tagType in tagTypes)
                {
                    typeFinder.Setup(x => x.Find(It.Is<IWebElement>(we => we.TagName == tagType.Key)))
                        .Returns<IWebElement>(x => tagType.Value);
                }
            }
            if (inputTypes != null)
            {
                foreach (var inputType in inputTypes)
                {
                    typeFinder.Setup(x => x.Find(It.Is<IWebElement>(we => we.GetAttribute("type") == inputType.Key)))
                        .Returns<IWebElement>(x => inputType.Value);
                }
            }
            return typeFinder.Object;
        }
    }
}