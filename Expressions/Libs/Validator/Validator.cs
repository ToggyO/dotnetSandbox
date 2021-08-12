using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Expressions.Libs.Validator
{
    public class Validation<T>
    {
        public PropertyInfo Property { get; set; }
        public Func<T, bool> Predicate { get; set; }
    }

    public class ValidationResult
    {
        
    }
    
    public class Validator<T> where T : class
    {
        private List<Validation<T>> _validations;

        public Validator()
        {
            _validations = new List<Validation<T>>();
        }

        public void AddValidation<TProp>(
            Expression<Func<T, TProp>> propertyExpression, Func<T, bool> predicate)
        {
            
        }

        public bool Validate(T obj)
        {
            var validationResults = new Boolean[] { };

            foreach (var validation in _validations)
            {
                var isValid = validation.Predicate(validation.Property.GetValue());
            }
        }
    }
}