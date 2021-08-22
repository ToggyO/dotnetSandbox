using System;
using System.Reflection;

namespace Expressions.Libs.Validator
{
    public class ValidationRule<TProp> : IValidationRule<TProp>
    {
        Func<object, bool> IValidationRule.Predicate { get; set; }
        public PropertyInfo Property { get; set; }
        public Func<TProp, bool> Predicate { get; set; }
        public bool Validate(object obj) => Predicate((TProp) Property.GetValue(obj));
    }
}