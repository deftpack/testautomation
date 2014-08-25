using System;

namespace DeftPack.TestAutomation.Selenium.Extensions
{
    public class TextNotFoundException : Exception
    {
        public TextNotFoundException(string expected, string found) 
            : base(string.Format("Expected Text : '{0}' does not match with the text : '{1}'", expected, found))
        { }

        public TextNotFoundException(string expected)
            : base(string.Format("Expected Text : '{0}' has not been found", expected))
        { }
    }
}
