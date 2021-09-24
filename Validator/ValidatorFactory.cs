using System;

namespace Validator
{
    /// <summary>
    /// Factory for creating validators
    /// </summary>
    public class ValidatorFactory : IValidatorFactory
    {
        /// <summary>
        /// Gets a validator for a type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IValidator<T> GetValidator<T>() where T : class => (IValidator<T>)GetValidator(typeof(T));

        /// <summary>
        /// Gets a validator for a type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IValidator GetValidator(Type type)
        {
            var genericType = typeof(IValidator<>).MakeGenericType(type);
            return CreateInstance(genericType);
        }

        /// <summary>
        /// Instantiates the validator
        /// </summary>
        /// <param name="validatorType"></param>
        /// <returns></returns>
        public virtual IValidator CreateInstance(Type validatorType)
            => (IValidator)Activator.CreateInstance(validatorType);
    }
}