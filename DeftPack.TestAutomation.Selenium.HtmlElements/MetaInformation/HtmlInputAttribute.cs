using System;

namespace DeftPack.TestAutomation.Selenium.HtmlElements.MetaInformation
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class HtmlInputAttribute : Attribute
    {
        public string InputType { get; private set; }

        public HtmlInputAttribute(InputTypes type)
        {
            InputType = InputType;
        }
    }
}
