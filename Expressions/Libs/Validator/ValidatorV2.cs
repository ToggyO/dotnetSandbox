using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Expressions.Libs.Validator
{
    // public class Validation<TProp>
    // {
    //     public PropertyInfo Property { get; set; }
    //     public Func<TProp, bool> Predicate { get; set; }
    // }
    //
    // public class ValidationResult
    // {
    //     
    // }
    
    public class ValidatorV2<T> where T : class
    {
        private List<bool> _validationResults;
        private delegate ValidationV2<TProp> _validations<TProp>(ValidationV2<TProp> validation);
        // private delegate void _validations<TObject>(TObject obj);

        public ValidatorV2() => _validationResults = new List<bool>();

        public ValidatorV2<T> AddValidation<TProp>(
            Expression<Func<T, TProp>> propertyExpression, Func<TProp, bool> predicate)
        {
            var propertyInfo = (PropertyInfo) ((MemberExpression) propertyExpression.Body)?.Member;

            if (propertyInfo is null)
                throw new InvalidOperationException("Please provide a valid property expression.");

            // var kek = AddValidation;
            // (new ValidationV2<TProp>
            // {
            //     Property = propertyInfo,
            //     Predicate = predicate,
            // });
            _validations += AddValidation;
            return this;
        }

        public bool Validate(T obj)
        {

            

            return validationResults.Any(x => !x);
        }

        // private bool Validate(T obj)
        // {
        //     var result = validation.Predicate((T) validation.Property.GetValue(obj));
        //     validationResults.Add(result);
        // }

        private ValidationV2<TProp> AddValidation<TProp>(ValidationV2<TProp> validation)
        {
            
        }

        private class ValidationV2<TProp>
        {
            public PropertyInfo Property { get; set; }
            public Func<TProp, bool> Predicate { get; set; }
        }
    }
}