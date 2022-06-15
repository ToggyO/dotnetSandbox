using System;

namespace Validator.DependencyInjectionExtensions
{
    /// <summary>
    /// Validator factory implementation that uses the asp.net service provider to construct validators.
    /// </summary>
    public class ServiceProviderValidatorFactory : ValidatorFactoryBase
    {
        /// <summary>
        /// Instance of <see cref="IServiceProvider"/>.
        /// </summary>
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Creates an instance of <see cref="ServiceProviderValidatorFactory"/>.
        /// </summary>
        /// <param name="serviceProvider">Instance of <see cref="IServiceProvider"/>.</param>
        public ServiceProviderValidatorFactory(IServiceProvider serviceProvider)
            => _serviceProvider = serviceProvider;


        /// <inheritdoc cref="ValidatorFactoryBase.CreateInstance"/>.
        public override IValidator CreateInstance(Type validatorType)
            => (IValidator)_serviceProvider.GetService(validatorType);
    }
}