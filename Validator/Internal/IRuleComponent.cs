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
        bool Validate(ValidationContext<T> context, TProperty value);
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