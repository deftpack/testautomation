using System;

namespace DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    internal class HtmlInputAttribute : HtmlTagAttribute
    {
        public InputTypes InputType { get; private set; }

        public HtmlInputAttribute(InputTypes type) : base ("input")
        {
            InputType = type;
        }
    }
}
