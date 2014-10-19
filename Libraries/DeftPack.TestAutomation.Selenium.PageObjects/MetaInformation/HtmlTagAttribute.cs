using System;

namespace DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation
{
    /// <summary>
    /// Describes which HTML tag could represent the marked element
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    internal class HtmlTagAttribute : Attribute
    {
        /// <summary>
        /// Name of the HTML tag
        /// </summary>
        public string TagName { get; private set; }

        public HtmlTagAttribute(string tagName)
        {
            TagName = tagName;
        }
    }
}
