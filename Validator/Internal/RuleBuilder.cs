using Validator.Validators;

namespace Validator.Internal
{
    ///<inheritdoc cref="IRuleBuilder{T, TProperty}"/>
    internal class RuleBuilder<T, TProperty> : IRuleBuilder<T, TProperty>, IRuleBuilderInternal<T, TProperty>
    {
        ///<inheritdoc cref="IRuleBuilder{T, TProperty}.Rule"/>
        public IValidationRuleInternal<T, TProperty> Rule { get; }

        public RuleBuilder(IValidationRuleInternal<T, TProperty> rule) => Rule = rule;

        ///<inheritdoc cref="IRuleBuilder{T, TProperty}.SetValidator"/>
        public IRuleBuilder<T, TProperty> SetValidator(IPropertyValidator<T, TProperty> validator)
        {
            Rule.AddValidator(validator);
            return this;
        }

        /// <summary>
        /// Add rule component to rule instance.
        /// </summary>
        /// <param name="component">Instance of <see cref="IRuleComponent{T, TProperty}"/>.</param>
        public void AddComponent(IRuleComponent<T, TProperty> component) => Rule.Components.Add(component);
    }
}