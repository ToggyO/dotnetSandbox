using System;
using System.Linq.Expressions;
using System.Reflection;

using Expressions.Libs.Validator;

namespace Validator.Internal
{
    /// <summary>
    /// Defines a rule associated with a property.
    /// </summary>
    /// <typeparam name="T">Type of instance to validate.</typeparam>
    /// <typeparam name="TProperty">Type of instance member.</typeparam>
    internal class PropertyRule<T, TProperty> : ValidationRule<T, TProperty>, IValidationRuleInternal<T, TProperty>
    {
        public PropertyRule(MemberInfo member, Func<T, TProperty> propertyFunc, Type typeToValidate)
            : base(member, propertyFunc, typeToValidate)
        {}

        /// <summary>
		/// Creates a new property rule from a lambda expression.
		/// </summary>
        public static PropertyRule<T, TProperty> Create(Expression<Func<T, TProperty>> expression)
        {
            var member = expression.GetMember();
            return new PropertyRule<T, TProperty>(member, x => expression.Compile()(x), typeof(TProperty));
        }

        public bool Validate(ValidationContext<T> context)
        {
            throw new NotImplementedException();
        }
    }
}
