using System;
using System.Collections.Generic;
using System.Reflection;
using Validator.Validators;

namespace Validator.Internal
{
    /// <summary>
    /// Defines a rule associated with a property which can have multiple validators.
    /// </summary>
    /// <typeparam name="T">Type of instance to validate.</typeparam>
    /// <typeparam name="TProperty">Type of instance member.</typeparam>
    public interface IValidationRule<T, TProperty> : IValidationRule<T>
    {
        /// <summary>
		/// Function that can be invoked to retrieve the value of the property.
		/// </summary>
		public Func<T, TProperty> PropertyFunc { get; }

        /// <summary>
        /// Adds a validator to this rule.
        /// </summary>
        /// <param name="validator"></param>
        void AddValidator(IPropertyValidator<T, TProperty> validator);
    }

    /// <summary>
    /// Defines a rule associated with a property which can have multiple validators.
    /// </summary>
    /// <typeparam name="T">Type of instance to validate.</typeparam>
    public interface IValidationRule<T> : IValidationRule
    {
        /// <summary>
		/// Gets the property value for this rule. Note that this bypasses all conditions.
		/// </summary>
		/// <param name="instance">The model from which the property value should be retrieved.</param>
		/// <returns>The property value.</returns>
		object GetPropertyValue(T instance);
    }

    /// <summary>
    /// Defines a rule associated with a property which can have multiple validators.
    /// </summary>
    public interface IValidationRule
    {
        /// <summary>
        /// The components in this rule.
        /// </summary>
        IEnumerable<IRuleComponent> Components { get; }

        /// <summary>
        /// Returns the property name for the property being validated.
        /// Returns null if it is not a property being validated (eg a method call)
        /// </summary>
        public string PropertyName { get; }

        /// <summary>
        /// Property associated with this rule.
        /// </summary>
        public MemberInfo Member { get; }
        
        /// <summary>
        /// Type of the property being validated
        /// </summary>
        public Type TypeToValidate { get; }
        
        /// <summary>
        /// Whether the rule has a condition defined.
        /// </summary>
        bool HasCondition { get; }
    }
}