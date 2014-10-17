using System;
using System.Collections.Generic;

namespace DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class CheckUrlAttribute : Attribute
    {
        public IEnumerable<string> UrlParts { get; private set; }

        public CheckUrlAttribute(string urlPart)
            : this(new[] { urlPart })
        { }

        public CheckUrlAttribute(params string[] urlParts)
        {
            UrlParts = urlParts;
        }
    }
}
