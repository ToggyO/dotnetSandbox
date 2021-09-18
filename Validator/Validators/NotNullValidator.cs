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

        protected override string GetDefaultMessageTemplate(string errorCode)
        {
            return base.GetDefaultMessageTemplate(errorCode);
        }
    }
    
    public interface INotNullValidator : IPropertyValidator
    {}
}