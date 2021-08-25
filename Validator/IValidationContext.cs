using System.Collections.Generic;

using Expressions.Libs.Validator.Results;

namespace Validator
{
    /// <summary>
    /// Validation context.
    /// </summary>
    public interface IValidationContext
    {
        /// <summary>
        /// The object currently being validated.
        /// </summary>
        object InstanceToValidate { get; }
    }
    
    /// <summary>
    /// Represents a collection of validation errors.
    /// </summary>
    internal interface IHasFailures
    {
        /// <summary>
        /// Gets or sets a collection of validation errors <see cref="ValidationFailure"/>.
        /// </summary>
        List<ValidationFailure> Failures { get; }
    }
}