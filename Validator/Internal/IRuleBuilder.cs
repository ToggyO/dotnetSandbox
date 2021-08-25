using Expressions.Libs.Validator;

namespace Validator.Internal
{
    public interface IRuleBuilder<T, TProperty>
    {
        IRuleBuilder<T, TProperty> SetValidator(IValidationRule<T,TProperty> rule);
    }
}