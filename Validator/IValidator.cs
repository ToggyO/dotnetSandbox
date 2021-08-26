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
    public interface IValidator<T> where T : class
    {
        /// <summary>
		/// Defines a validation rule for a specify property.
		/// </summary>
		/// <example>
		/// AddValidationFor(x => x.Surname)...
		/// </example>
        /// <typeparam name="TProperty">The type of property being validated.</typeparam>
        /// <param name="expression">The expression representing the property to validate.</param>
        /// <returns>Instance of <see cref="IRuleBuilder{T, TProperty}"/> on which validators can be defined.</returns>
        IRuleBuilder<T, TProperty> AddValidationFor<TProperty>(Expression<Func<T, TProperty>> expression);

        // TODO: check
        Validator<T> AddValidation<TProp>(
            Expression<Func<T, TProp>> propertyExpression, Func<TProp, bool> predicate);

        /// <summary>
        /// Validates the specified instance.
        /// </summary>
        /// <param name="context">Instance of <see cref="ValidationContext{T}"/>.</param>
        /// <returns>A ValidationResult object containing any validation failures.</returns>
        ValidationResult Validate(ValidationContext<T> context);
    }
}