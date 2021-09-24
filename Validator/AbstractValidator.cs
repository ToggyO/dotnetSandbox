using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using Validator.Internal;
using Validator.Results;

namespace Validator
{
    /// <inheritdoc cref="IValidator{T}"/>.
    public abstract class AbstractValidator<T> : IValidator<T>  where T : class
    {
        /// <summary>
        /// Collection of validation rules.
        /// </summary>
        internal List<IValidationRuleInternal<T>> _validationRules = new ();

        /// <inheritdoc cref="IValidator{T}.AddValidationFor{TProperty}"/>.
        public IRuleBuilder<T, TProperty> AddValidationFor<TProperty>(Expression<Func<T, TProperty>> expression)
        {
            expression.Guard("Cannot pass null to AddValidationFor", nameof(expression));
            var rule = PropertyRule<T, TProperty>.Create(expression);
            _validationRules.Add(rule);
            return new RuleBuilder<T, TProperty>(rule);
        }
        
        // public AbstractValidator<T> AddValidation<TProp>(
        //     Expression<Func<T, TProp>> propertyExpression, Func<TProp, bool> predicate)
        // {
        //     //var propertyInfo = (PropertyInfo) ((MemberExpression) propertyExpression.Body)?.Member;
        //
        //     //if (propertyInfo is null)
        //     //    throw new InvalidOperationException("Please provide a valid property expression.");
        //     
        //     //_validationRules.Add(new ValidationRule<TProp>
        //     //{
        //     //    Property = propertyInfo,
        //     //    Predicate = predicate,
        //     //});
        //     return this;
        // }

        
        /// <summary>
        /// Defines a validation rule for a specify property.
        /// </summary>
        /// <example>
        /// AddValidationFor(x => x.Surname)...
        /// </example>
        /// <typeparam name="TProperty">The type of property being validated.</typeparam>
        /// <param name="expression">The expression representing the property to validate.</param>
        /// <returns>Instance of <see cref="IRuleBuilder{T, TProperty}"/> on which validators can be defined.</returns>
        public ValidationResult Validate(ValidationContext<T> context)
        {
            var result = new ValidationResult(context.Failures);

            foreach (var rule in _validationRules)
                rule.Validate(context);

            return result;
        }

        /// <inheritdoc cref="IValidator.Validate"/>.
        ValidationResult IValidator.Validate(IValidationContext context)
        {
            context.Guard("Cannot pass null to Validate", nameof(context));
            return Validate(ValidationContext<T>.GetFromNonGenericContext(context));

        }
    }
}