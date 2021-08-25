using Validator.Internal;
using Validator.Validators;

namespace Validator
{
    /// <summary>
	/// Extension methods that provide the default set of validators.
	/// </summary>
    public static class ValidatorExtensions
    {
        /// <summary>
		/// Defines a 'not null' validator on the current rule builder.
		/// Validation will fail if the property is null.
		/// </summary>
		/// <typeparam name="T">Type of object being validated.</typeparam>
		/// <typeparam name="TProperty">Type of property being validated.</typeparam>
		/// <param name="ruleBuilder">The rule builder on which the validator should be defined.</param>
		/// <returns>Current instance of <see cref="IRuleBuilder{T, TProperty}"/>.</returns>
        public static IRuleBuilder<T, TProperty> NotNull<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
            => ruleBuilder.SetValidator(new NotNullValidator<T, TProperty>());
    }
}
