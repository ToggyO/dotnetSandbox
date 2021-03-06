using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Expressions.Libs.Validator.Results;

namespace Expressions.Libs.Validator
{
    public class Validator<T> : IValidator<T>  where T : class
    {
        private List<IValidationRule> _validationRules;

        public Validator() =>_validationRules = new List<IValidationRule>();

        /// <summary>
        /// Add validation rule by expression with boolean result.
        /// </summary>
        /// <param name="propertyExpression">Expression, that determines the property to validate.</param>
        /// <param name="predicate">Validation condition.</param>
        /// <typeparam name="TProp">Type of property to validate.</typeparam>
        /// <returns>Instance of <see cref="Validator{T}"/>.</returns>
        /// <exception cref="InvalidOperationException">Exception.</exception>
        public Validator<T> AddValidation<TProp>(
            Expression<Func<T, TProp>> propertyExpression, Func<TProp, bool> predicate)
        {
            var propertyInfo = (PropertyInfo) ((MemberExpression) propertyExpression.Body)?.Member;

            if (propertyInfo is null)
                throw new InvalidOperationException("Please provide a valid property expression.");
            
            _validationRules.Add(new ValidationRule<TProp>
            {
                Property = propertyInfo,
                Predicate = predicate,
            });
            return this;
        }

        public bool Validate(T obj)
        {
            var validationResults = new List<ValidationFailure>();

            foreach (var validation in _validationRules)
                validationResults.Add(validation.Validate(obj));

            return validationResults.All(x => x);
        }
    }
}