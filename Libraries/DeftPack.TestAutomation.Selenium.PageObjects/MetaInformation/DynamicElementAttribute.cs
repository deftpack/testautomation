using System;

namespace DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation
{
    /// <summary>
    /// Marks elements which dynamically added to the DOM so they are not present at the beginning
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class DynamicElementAttribute : Attribute { }
}
