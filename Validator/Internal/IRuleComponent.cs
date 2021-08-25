using System;

using Validator.Validators;

namespace Validator.Internal
{
    // TODO: check
    public interface IRuleComponent<T,out TProperty> : IRuleComponent
    {

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