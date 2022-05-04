using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;

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
            var compiled = AccessorCache<T>.GetCachedAccessor(member, expression);
            return new PropertyRule<T, TProperty>(member, x => compiled(x), typeof(TProperty));
        }

        /// <inheritdoc cref="IValidationRuleInternal{T}.Validate"/>
        public void Validate(ValidationContext<T> context)
        {
            var accessor = new Lazy<TProperty>(() => PropertyFunc(context.InstanceToValidate), LazyThreadSafetyMode.None);
            context.InitializeForPropertyValidator(PropertyName);

            foreach (var validator in Components)
            {
                context.MessageFormatter.Reset();

                bool isValid = validator.Validate(context, accessor.Value);
                if (!isValid)
                {
                    PrepareMessageFormatterForValidationError(context, accessor.Value);
                    context.Failures.Add(CreateValidationError(context, accessor.Value, validator));
                }
            }
        }
    }
}
