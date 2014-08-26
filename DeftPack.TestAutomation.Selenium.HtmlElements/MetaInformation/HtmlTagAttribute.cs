using System;

namespace DeftPack.TestAutomation.Selenium.HtmlElements.MetaInformation
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class HtmlTagAttribute : Attribute
    {
        public string TagName { get; private set; }

        public HtmlTagAttribute(string tagName)
        {
            TagName = tagName;
        }
    }
}
