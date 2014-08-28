using System;

namespace DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    internal class HtmlTagAttribute : Attribute
    {
        public string TagName { get; private set; }

        public HtmlTagAttribute(string tagName)
        {
            TagName = tagName;
        }
    }
}
