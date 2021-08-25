using System;

using Validator.Validators;

namespace Validator.Internal
{
    /// <inheritdoc cref="IRuleComponent"/>
    public class RuleComponent<T, TProperty> : IRuleComponent<T, TProperty>
    {
        /// <summary>
        /// Instance of <see cref="IPropertyValidator{T, TProperty}"/>.
        /// </summary>
        private readonly IPropertyValidator<T, TProperty> _propertyValidator;

        /// <summary>
        /// Error message.
        /// </summary>
        private readonly string _errorMessage;

        // TODO: add description
        private Func<ValidationContext<T>, bool> _condition;

        /// <inheritdoc cref="IRuleComponent.HasCondition"/>
        public bool HasCondition => throw new System.NotImplementedException();

        /// <inheritdoc cref="IRuleComponent.Validator"/>
        public IPropertyValidator Validator => _propertyValidator;

        /// <inheritdoc cref="IRuleComponent.ErrorCode"/>
        public string ErrorCode { get; set; }

        /// <inheritdoc cref="IRuleComponent.ErrorMessage"/>
        public string ErrorMessage { get; set; }

        public RuleComponent(IPropertyValidator<T, TProperty> propertyValidator) => _propertyValidator = propertyValidator;
    }
}