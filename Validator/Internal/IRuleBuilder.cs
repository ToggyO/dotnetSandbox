using Validator.Validators;

namespace Validator.Internal
{
    /// <summary>
    /// Rule builder.
    /// </summary>
    /// <typeparam name="T">Type of instance to validate.</typeparam>
    /// <typeparam name="TProperty">Type of instance member.</typeparam>
    public interface IRuleBuilder<T, TProperty>
    {
        /// <summary>
        /// Associates a validator with this the property for this rule builder.
        /// </summary>
        /// <param name="rule">The validator to set.</param>
        /// <returns>Current instance of <see cref="IRuleBuilder{T, TProperty}"/></returns>
        IRuleBuilder<T, TProperty> SetValidator(IPropertyValidator<T, TProperty> validator);
    }

    internal interface IRuleBuilderInternal<T, TProperty>
    {
        /// <summary>
		/// The rule being created by this RuleBuilder.
		/// </summary>
        IValidationRuleInternal<T, TProperty> Rule { get; }
    }
}