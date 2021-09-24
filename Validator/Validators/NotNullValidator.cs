using Validator.Internal;

namespace Validator.Validators
{
    /// <summary>
    /// Check if value is null.
    /// </summary>
    /// <typeparam name="T">Type of instance to validate.</typeparam>
    /// <typeparam name="TProperty">Property type.</typeparam>
    public class NotNullValidator<T, TProperty> : PropertyValidator<T, TProperty>, INotNullValidator
    {
        /// <inheritdoc cref="PropertyValidator{T,TProperty}.Name"/>
        public override string Name => "NotNullValidator";

        /// <inheritdoc cref="PropertyValidator{T,TProperty}.IsValid"/>
        public override bool IsValid(ValidationContext<T> context, TProperty value) => value != null;

        /// <inheritdoc cref="PropertyValidator{T,TProperty}.GetDefaultMessageTemplate"/>
        protected override string GetDefaultMessageTemplate(string errorCode)
            => ValidatorOptions.Global.MessageManager.ResolveErrorMessageUsingErrorCode(errorCode, Name);
    }
    
    public interface INotNullValidator : IPropertyValidator
    {}
}