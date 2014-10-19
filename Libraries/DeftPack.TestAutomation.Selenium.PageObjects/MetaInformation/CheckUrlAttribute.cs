using System;
using System.Collections.Generic;

namespace DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation
{
    /// <summary>
    /// Describe the URL check for a view
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class CheckUrlAttribute : Attribute
    {
        /// <summary>
        /// URL parts that will be checked if the address contains them
        /// </summary>
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
