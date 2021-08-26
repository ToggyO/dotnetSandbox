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
        private readonly string _errorMessage = "KEK";

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

        /// <summary>
        /// Validate property value.
        /// </summary>
        /// <param name="context">Instance of <see cref="ValidationContext{T}"/>.</param>
        /// <param name="value">Value being validate.</param>
        /// <returns>Boolean validation result.</returns>
        internal bool Validate(ValidationContext<T> context, TProperty value) => Validate(context, value);

        /// <inheritdoc cref="IRuleComponent{T, TProperty}.Validate"/>
        bool IRuleComponent<T, TProperty>.Validate(ValidationContext<T> context, TProperty value)
            => _propertyValidator.IsValid(context, value);
    }
}