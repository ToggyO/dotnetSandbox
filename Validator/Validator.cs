using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using Validator.Internal;
using Validator.Results;

namespace Validator
{
    /// <inheritdoc cref="IValidator{T}"/>.
    public class Validator<T> : IValidator<T>  where T : class
    {
        /// <summary>
        /// Collection of validation rules.
        /// </summary>
        internal List<IValidationRuleInternal<T>> _validationRules;

        public Validator() =>_validationRules = new List<IValidationRuleInternal<T>>();

        /// <inheritdoc cref="IValidator{T}.AddValidationFor{TProperty}"/>.
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

        /// <inheritdoc cref="IValidator{T}.Validate"/>.
        public ValidationResult Validate(ValidationContext<T> context)
        {
            var result = new ValidationResult(context.Failures);

            foreach (var rule in _validationRules)
                rule.Validate(context);

            return result;
        }
    }
}