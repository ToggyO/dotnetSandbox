using System;
using System.Collections.Generic;
using System.Reflection;
using Validator.Internal;
using Validator.Validators;

namespace Expressions.Libs.Validator
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
        private readonly List<RuleComponent<T, TProperty>> _components = new();

        /// <inheritdoc cref="IValidationRule.Components" />
        IEnumerable<IRuleComponent> IValidationRule.Components => _components;

        /// <summary>
        /// Collection of <see cref="RuleComponent{T, TProperty}"/>
        /// </summary>
        public List<RuleComponent<T, TProperty>> Components => _components;

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
            // TODO: check
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
    }
}