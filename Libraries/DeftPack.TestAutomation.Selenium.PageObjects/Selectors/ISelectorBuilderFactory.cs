using System;
using System.Collections.Generic;
using DeftPack.TestAutomation.Selenium.PageObjects.Elements;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Selectors
{
    public interface ISelectorBuilderFactory
    {
        IEnumerable<ISelectorBuilder> Create<TElement>() where TElement : Element;

        IEnumerable<ISelectorBuilder> Create<TElement>(Func<ISelectorBuilder, ISelectorBuilder> builderFunc)
            where TElement : Element;
    }
}