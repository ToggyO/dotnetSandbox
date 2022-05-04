using System;

namespace Validator
{
    /// <summary>
    /// Factory for creating validators
    /// </summary>
    public abstract class ValidatorFactoryBase : IValidatorFactory
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
        /// <param name="validatorType">Type io validator.</param>
        /// <returns>Instance of <see cref="IValidator"/>.</returns>
        public abstract IValidator CreateInstance(Type validatorType);
    }
}