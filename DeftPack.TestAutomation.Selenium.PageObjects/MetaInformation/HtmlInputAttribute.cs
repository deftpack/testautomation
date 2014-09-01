using System;

namespace DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    internal class HtmlInputAttribute : Attribute
    {
        public InputTypes InputType { get; private set; }

        public HtmlInputAttribute(InputTypes type)
        {
            InputType = type;
        }
    }
}
