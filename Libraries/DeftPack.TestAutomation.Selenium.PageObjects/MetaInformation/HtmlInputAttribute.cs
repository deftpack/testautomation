using System;

namespace DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation
{
    /// <summary>
    /// Marks an element as it could represented by an input DOM object
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    internal class HtmlInputAttribute : Attribute
    {
        /// <summary>
        /// Matching the type attribute of the DOM object 
        /// </summary>
        public InputTypes InputType { get; private set; }

        public HtmlInputAttribute(InputTypes type)
        {
            InputType = type;
        }
    }
}
