using System;
using System.Collections.Generic;
using System.Reflection;
using Validator.Internal;

namespace Expressions.Libs.Validator
{
    public class ValidationRule<T, TProperty> : IValidationRule<T, TProperty>
    {
        private readonly IList<RuleComponent> _components = new List<RuleComponent>();
        public PropertyInfo Property { get; set; }
        public Func<TProperty, bool> Predicate { get; set; }
        public bool Validate(object obj) => Predicate((TProperty) Property.GetValue(obj));
    }
}