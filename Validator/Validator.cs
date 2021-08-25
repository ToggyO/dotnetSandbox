using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Validator.Internal;

namespace Validator
{
    /// <summary>
	/// Class for object validators.
	/// </summary>
	/// <typeparam name="T">The type of the object being validated. (temporrary ref values only) </typeparam>
    public class Validator<T> : IValidator<T>  where T : class
    {
        /// <summary>
        /// Collection of validation rules.
        /// </summary>
        internal List<IValidationRuleInternal<T>> _validationRules;

        public Validator() =>_validationRules = new List<IValidationRuleInternal<T>>();

        /// <summary>
		/// Defines a validation rule for a specify property.
		/// </summary>
		/// <example>
		/// AddValidationFor(x => x.Surname)...
		/// </example>
        /// <typeparam name="TProperty">The type of property being validated.</typeparam>
        /// <param name="expression">The expression representing the property to validate.</param>
        /// <returns>Instance of <see cref="IRuleBuilder{T, TProperty}"/> on which validators can be defined.</returns>
        public IRuleBuilder<T, TProperty> AddValidationFor<TProperty>(Expression<Func<T, TProperty>> expression)
        {
            expression.Guard("Cannot pass null to AddValidationFor", nameof(expression));
            var rule = PropertyRule<T, TProperty>.Create(expression);
            _validationRules.Add(rule);
            return new RuleBuilder<T, TProperty>(rule);
        }
        
        public Validator<T> AddValidation<TProp>(
            Expression<Func<T, TProp>> propertyExpression, Func<TProp, bool> predicate)
        {
            //var propertyInfo = (PropertyInfo) ((MemberExpression) propertyExpression.Body)?.Member;

            //if (propertyInfo is null)
            //    throw new InvalidOperationException("Please provide a valid property expression.");
            
            //_validationRules.Add(new ValidationRule<TProp>
            //{
            //    Property = propertyInfo,
            //    Predicate = predicate,
            //});
            return this;
        }

        public bool Validate(T obj)
        {
            //var validationResults = new List<ValidationFailure>();

            //foreach (var validation in _validationRules)
            //    validationResults.Add(validation.Validate(obj));

            //return validationResults.All(x => x);
            return true;
        }
    }
}