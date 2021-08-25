namespace Validator.Internal
{
    /// <inheritdoc cref="IRuleComponent"/>
    public class RuleComponent : IRuleComponent
    {
        /// <inheritdoc cref="IRuleComponent.ErrorCode"/>
        public string ErrorCode { get; set; }

        /// <inheritdoc cref="IRuleComponent.ErrorMessage"/>
        public string ErrorMessage { get; set; }
    }
}