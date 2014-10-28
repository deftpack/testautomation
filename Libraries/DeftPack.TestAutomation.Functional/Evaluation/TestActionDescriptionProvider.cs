using System;

namespace DeftPack.TestAutomation.Functional.Evaluation
{
    /// <summary>
    /// Retrieves the test action meta information
    /// </summary>
    internal class TestActionDescriptionProvider : ITestActionDescriptionProvider
    {
        private readonly Type _attributeType;

        public TestActionDescriptionProvider()
        {
            _attributeType = typeof(TestActionDescriptionAttribute);
        }

        /// <summary>
        /// Finds the test description for a given test action or function
        /// </summary>
        /// <typeparam name="TAction">Type of the test action or function to be inspected</typeparam>
        /// <returns>Test action/function description</returns>
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
