using System;

namespace DeftPack.TestAutomation.Functional.Evaluation
{
    public class TestActionDescriptionProvider : ITestActionDescriptionProvider
    {
        private readonly Type _attributeType;

        public TestActionDescriptionProvider()
        {
            _attributeType = typeof(TestActionDescriptionAttribute);
        }

        public ITestActionDescription GetDescription<TAction>() where TAction : TestAction
        {
            var targetType = typeof(TAction);
            var description = (ITestActionDescription)Attribute.GetCustomAttribute(targetType, _attributeType);

            if (description == null)
                throw new MissingExpectedAttributeException(targetType, _attributeType);

            return description;
        }
    }
}
