using Expressions.Libs.Validator;

namespace Validator.Internal
{
    public class RuleBuilder<T, TProperty> : IRuleBuilder<T, TProperty>
    {
        public IValidationRule<T, TProperty> Rule { get; }

        public IRuleBuilder<T, TProperty> SetValidator(IValidationRule<T, TProperty> rule)
        {
            throw new System.NotImplementedException();
        }
    }
}