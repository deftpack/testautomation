using DeftPack.TestAutomation.Selenium.PageObjects.Selectors;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace DeftPack.TestAutomation.Selenium.PageObjects
{
    public abstract class Page
    {
        private readonly IWebDriver _webDriver;

        protected Page(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        protected TElement QueryElement<TElement>(Func<ISelectorBuilder> builderFunc)
        {
            throw new System.NotImplementedException();
        }

        protected IEnumerable<TElement> QueryElements<TElement>(Func<ISelectorBuilder> builderFunc)
        {
            throw new System.NotImplementedException();
        }


        protected TElement QueryElement<TElement>(Func<ISelectorBuilder, ISelectorBuilder> builderFunc)
        {
            throw new System.NotImplementedException();
        }

        protected IEnumerable<TElement> QueryElements<TElement>(Func<ISelectorBuilder, ISelectorBuilder> builderFunc)
        {
            throw new System.NotImplementedException();
        }
    }
}
