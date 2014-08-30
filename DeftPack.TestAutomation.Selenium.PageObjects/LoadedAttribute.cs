using System;

namespace DeftPack.TestAutomation.Selenium.PageObjects
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class LoadedAttribute : Attribute
    {
        public bool IsStrict { get; private set; }
        public string UrlPart { get; private set; }

        public LoadedAttribute(string urlPart, bool isStrict = false)
        {
            UrlPart = urlPart;
            IsStrict = isStrict;
        }
    }
}
