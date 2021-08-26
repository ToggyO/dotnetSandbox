using System;

using Validator.Validators;

namespace Validator.Internal
{
    /// <summary>
    /// An individual component within a rule with a validator attached.
    /// </summary>
    /// <typeparam name="T">Type of instance to validate.</typeparam>
    /// <typeparam name="TProperty">Type of property being validated.</typeparam>
    internal interface IRuleComponent<T,in TProperty> : IRuleComponent
    {
	    /// <summary>
	    /// Validate instance by rule.
	    /// </summary>
	    /// <param name="context">Instance of <see cref="ValidationContext{T}"/>.</param>
	    /// <param name="value">Value being validate.</param>
	    /// <returns></returns>
        bool Validate(ValidationContext<T> context, TProperty value);

	    /// <summary>
	    /// Gets the error message. If a context is supplied, it will be used to format the message if it has placeholders.
	    /// If no context is supplied, the raw unformatted message will be returned, containing placeholders.
	    /// </summary>
	    /// <param name="context">The validation context.</param>
	    /// <param name="value">The current property value.</param>
	    /// <returns>Either the formatted or unformatted error message.</returns>
	    string GetErrorMessage(ValidationContext<T> context, TProperty value);
    }

    /// <summary>
    /// An individual component within a rule with a validator attached.
    /// </summary>
    public interface IRuleComponent
    {
        /// <summary>
		/// Whether or not this validator has a condition associated with it.
		/// </summary>
		bool HasCondition { get; }

        /// <summary>
		/// The validator associated with this component.
		/// </summary>
		IPropertyValidator Validator { get; }

        /// <summary>
        /// The error code associated with this rule component.
        /// </summary>
        string ErrorCode { get; set; }

        /// <summary>
        /// The error message associated with this rule component.
        /// </summary>
        string ErrorMessage { get; set; }
    }
}