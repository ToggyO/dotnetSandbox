using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Validator.Results;
using Validator.Validators;

namespace Validator.Internal
{
    /// <summary>
    /// Defines a rule associated with a property which can have multiple validators.
    /// </summary>
    /// <typeparam name="T">Type of instance to validate.</typeparam>
    /// <typeparam name="TProperty">Type of instance member.</typeparam>
    internal abstract class ValidationRule<T, TProperty> : IValidationRule<T, TProperty>
    {
        /// <summary>
        /// Collection of <see cref="RuleComponent{T, TProperty}"/>
        /// </summary>
        private readonly List<IRuleComponent<T, TProperty>> _components = new();

        /// <inheritdoc cref="IValidationRule.Components" />
        IEnumerable<IRuleComponent> IValidationRule.Components => _components;

        /// <summary>
        /// Collection of <see cref="RuleComponent{T, TProperty}"/>
        /// </summary>
        public List<IRuleComponent<T, TProperty>> Components => _components;
        
        /// <inheritdoc cref="IValidationRuleInternal{T, TPropery}.Current"/>
        public IRuleComponent<T, TProperty> Current => _components.LastOrDefault();

        /// <inheritdoc cref="IValidationRule.PropertyName"/>
        public string PropertyName { get; }

        /// <inheritdoc cref="IValidationRule.Member"/>
        public MemberInfo Member { get; }

        /// <inheritdoc cref="IValidationRule.TypeToValidate"/>
        public Type TypeToValidate { get; }

        /// <inheritdoc cref="IValidationRule.HasCondition"/>
        public bool HasCondition { get; }

        /// <inheritdoc cref="IValidationRule{T, TProperty}.PropertyFunc"/>
        public Func<T, TProperty> PropertyFunc { get; }

        public ValidationRule(MemberInfo member, Func<T, TProperty> propertyFunc, Type typeToValidate)
        {
            Member = member;
            PropertyFunc = propertyFunc;
            TypeToValidate = typeToValidate;
            PropertyName = member.Name;
        }

        /// <inheritdoc cref="IValidationRule{T, TProperty}.AddValidator"/>
        public void AddValidator(IPropertyValidator<T, TProperty> validator)
        {
            var component = new RuleComponent<T, TProperty>(validator);
            _components.Add(component);
        }

        /// <summary>
		/// Gets the property value for this rule. Note that this bypasses all conditions.
		/// </summary>
		/// <param name="instance">The model from which the property value should be retrieved.</param>
		/// <returns>The property value.</returns>
        public TProperty GetPropertyValue(T instance) => PropertyFunc(instance);
        object IValidationRule<T>.GetPropertyValue(T instance) => PropertyFunc(instance);

        /// <summary>
        /// Prepares the <see cref="MessageFormatter"/> of <paramref name="context"/> for an upcoming <see cref="ValidationFailure"/>.
        /// </summary>
        /// <param name="context">The validator context</param>
        /// <param name="value">Property value.</param>
        protected void PrepareMessageFormatterForValidationError(ValidationContext<T> context, TProperty value)
        {
            context.MessageFormatter.AppendPropertyName(context.PropertyName);
            context.MessageFormatter.AppendPropertyValue(value);
        }

        /// <summary>
		/// Creates an error validation result for this validator.
		/// </summary>
		/// <param name="context">The validator context.</param>
		/// <param name="value">The property value.</param>
		/// <param name="component">The current rule component.</param>
		/// <returns>Returns an error validation result.</returns>
        protected ValidationFailure CreateValidationError(
            ValidationContext<T> context, TProperty value, IRuleComponent<T, TProperty> component)
        {
            string error = component.GetErrorMessage(context, value);

            var failure = new ValidationFailure(PropertyName, error);

            failure.ErrorCode = component.ErrorCode ?? ValidatorOptions.Global.ErrorCodeResolver(component.Validator);
            return failure;
        }
    }
}