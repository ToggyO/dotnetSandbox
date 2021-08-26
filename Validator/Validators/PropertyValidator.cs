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

        string IPropertyValidator.GetDefaultMessageTemplate(string errorCode)
            => GetDefaultMessageTemplate(errorCode);

        /// <summary>
        /// Returns the default error message template for this validator, when not overridden.
        /// </summary>
        /// <param name="errorCode">The currently configured error code for the validator.</param>
        /// <returns></returns>
        protected virtual string GetDefaultMessageTemplate(string errorCode) => "No default error message has been specified";
    }
}