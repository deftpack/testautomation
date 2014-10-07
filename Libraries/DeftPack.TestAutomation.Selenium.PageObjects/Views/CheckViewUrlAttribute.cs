using System;
using System.Collections.Generic;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Views
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class CheckViewUrlAttribute : Attribute
    {
        public IEnumerable<string> UrlParts { get; private set; }

        public CheckViewUrlAttribute(string urlPart)
            : this(new[] { urlPart })
        { }

        public CheckViewUrlAttribute(params string[] urlParts)
        {
            UrlParts = urlParts;
        }
    }
}
