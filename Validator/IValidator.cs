using System;
using System.Linq.Expressions;

using Validator.Internal;
using Validator.Results;

namespace Validator
{
    /// <summary>
	/// Class for object validators.
	/// </summary>
	/// <typeparam name="T">The type of the object being validated. (temporrary ref values only) </typeparam>
    public interface IValidator<T> : IValidator where T : class
    {
        /// <summary>
        /// Validates the specified instance.
        /// </summary>
        /// <param name="context">Instance of <see cref="ValidationContext{T}"/>.</param>
        /// <returns>A ValidationResult object containing any validation failures.</returns>
        ValidationResult Validate(ValidationContext<T> context);
    }

    public interface IValidator
    {
	    /// <summary>
	    /// Validates the specified instance.
	    /// </summary>
	    /// <param name="context">Instance of <see cref="ValidationContext{T}"/>.</param>
	    /// <returns>A ValidationResult object containing any validation failures.</returns>
	    ValidationResult Validate(IValidationContext context);
    }
}