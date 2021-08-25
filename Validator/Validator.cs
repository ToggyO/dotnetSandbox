using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Expressions.Libs.Validator;
using Expressions.Libs.Validator.Results;
using Validator.Internal;

namespace Validator
{
    public class Validator<T> : IValidator<T>  where T : class
    {
        private List<IValidationRule> _validationRules;

        public Validator() =>_validationRules = new List<IValidationRule>();

        public IRuleBuilder<T, TProperty> AddValidationFor<TProperty>(Expression<Func<T, TProperty>> expression)
        {
            expression.Guard("Cannot pass null to AddValidationFor", nameof(expression));
            var rule = new ValidationRule<T, TProperty>()
        }
        
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