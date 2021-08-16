using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Expressions.Libs.Validator
{
    public class Validation
    {
        
        public PropertyInfo Property { get; set; }
        
        public Type PropertyType => Property.PropertyType.;

        // public Func<TProp, bool> Predicate { get; set; }
        public Func<Type, bool> Predicate { get; set; }
    }

    public class ValidationResult
    {
        
    }
    
    public class Validator<T> where T : class
    {
        private List<Validation> _validations;

        public Validator()
        {
            _validations = new List<Validation>();
        }

        public Validator<T> AddValidation<TProp>(
            Expression<Func<T, TProp>> propertyExpression, Func<TProp, bool> predicate)
        {
            var propertyInfo = (PropertyInfo) ((MemberExpression) propertyExpression.Body)?.Member;

            if (propertyInfo is null)
                throw new InvalidOperationException("Please provide a valid property expression.");
            
            _validations.Add(new Validation
            {
                Property = propertyInfo,
                Predicate = predicate,
            });
            return this;
        }

        public bool Validate(T obj)
        {
            var validationResults = new List<bool>();

            // foreach (var validation in _validations)
            // {
            //     var result = validation.Predicate(validation.Property.GetValue(obj));
            //     validationResults.Add(result);
            // }

            return validationResults.Any(x => !x);
        }
    }
}