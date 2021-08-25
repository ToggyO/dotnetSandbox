using System;
using System.Collections.Generic;
using System.Reflection;
using Validator.Validators;

namespace Validator.Internal
{
    public interface IValidationRule<T, TProperty> : IValidationRule
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="validator"></param>
        void AddValidator(IPropertyValidator<T, TProperty> validator);
        
        bool Validate(ValidationContext<T> context);
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
        public string PropertyName { get; set; }

        /// <summary>
        /// Property associated with this rule.
        /// </summary>
        public MemberInfo Member { get; set; }
        
        /// <summary>
        /// Type of the property being validated
        /// </summary>
        public Type TypeToValidate { get; }
        
        /// <summary>
        /// Whether the rule has a condition defined.
        /// </summary>
        bool HasCondition { get; }

        // TODO: check
        Func<object, bool> Predicate { get; set; }
        bool Validate(object obj);
    }
}