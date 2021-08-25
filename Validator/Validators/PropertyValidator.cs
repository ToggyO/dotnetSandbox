namespace Validator.Validators
{
    /// <summary>
    /// Base abstract property validator.
    /// </summary>
    /// <typeparam name="T">Type of instance to validate.</typeparam>
    /// <typeparam name="TProperty">Property type.</typeparam>
    public abstract class PropertyValidator<T, TProperty> : IPropertyValidator<T, TProperty>
    {
        /// <inheritdoc cref="IPropertyValidator{T,TProperty}.Name"/>.
        public abstract string Name { get; }
        
        /// <inheritdoc cref="IPropertyValidator{T,TProperty}.IsValid"/>.
        public abstract bool IsValid(ValidationContext<T> context, TProperty value);
    }
}