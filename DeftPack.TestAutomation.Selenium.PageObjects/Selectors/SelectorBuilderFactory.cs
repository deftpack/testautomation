﻿using DeftPack.TestAutomation.Selenium.PageObjects.Elements;
using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Selectors
{
    internal class SelectorBuilderFactory
    {
        public IEnumerable<ISelectorBuilder> Create<TElement>() where TElement : Element
        {
            var tagNames = typeof(TElement).GetCustomAttributes<HtmlTagAttribute>().Select(x => x.TagName);
            var inputTypes = typeof(TElement).GetCustomAttributes<HtmlInputAttribute>().Select(x => x.InputType);
            var selectorBuilders = tagNames.Select(x => (ISelectorBuilder)(new SelectorBuilder(x))).ToList();
            selectorBuilders.AddRange(inputTypes.Select(i => (ISelectorBuilder)(new SelectorBuilder(i))));
            return selectorBuilders;
        }

        public IEnumerable<ISelectorBuilder> Create<TElement>(Func<ISelectorBuilder, ISelectorBuilder> builderFunc)
            where TElement : Element
        {
            var baseBuilders = Create<TElement>();
            return baseBuilders.Select(builderFunc);
        }
    }
}
