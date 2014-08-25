using System;

namespace DeftPack.TestAutomation
{
    public class MissingExpectedAttributeException : Exception
    {
        public MissingExpectedAttributeException(Type targetType, Type attributeType)
            : base(string.Format("The type '{0}' is missing attribute '{1}'", targetType.FullName, attributeType.FullName))
        { }
    }
}
