using System;
using System.Collections.Generic;
using System.Reflection;

using Microsoft.Extensions.DependencyInjection;

namespace Validator.DependencyInjectionExtensions
{
    /// <summary>
    /// Service collection extensions.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds all validators in specified assemblies
        /// </summary>
        /// <param name="services">The collection of services</param>
        /// <param name="assemblies">The assemblies to scan</param>
        /// <param name="lifetime">The lifetime of the validators. The default is scoped (per-request in web applications)</param>
        /// <param name="includeInternalTypes">Include internal validators. The default is false.</param>
        /// <returns></returns>
        public static IServiceCollection AddValidatorsFromAssemblies(this IServiceCollection services,
            IEnumerable<Assembly> assemblies,
            ServiceLifetime lifetime = ServiceLifetime.Scoped,
            bool includeInternalTypes = false)
        {
            foreach (var assembly in assemblies)
                services.AddValidatorsFromAssembly(assembly, lifetime, includeInternalTypes);

            return services;
        }

        /// <summary>
        /// Adds all validators in specified assembly
        /// </summary>
        /// <param name="services">The collection of services</param>
        /// <param name="assembly">The assembly to scan</param>
        /// <param name="lifetime">The lifetime of the validators. The default is scoped (per-request in web application)</param>
        /// <param name="includeInternalTypes">Include internal validators. The default is false.</param>
        /// <returns></returns>
        public static IServiceCollection AddValidatorsFromAssembly(this IServiceCollection services,
            Assembly assembly, ServiceLifetime lifetime = ServiceLifetime.Scoped, bool includeInternalTypes = false)
        {
            AssemblyScanner
                .FindValidatorsInAssembly(assembly, includeInternalTypes)
                .ForEach(scanResult => services.AddScanResult(scanResult, lifetime));

            return services;
        }

        /// <summary>
        /// Adds all validators in the assembly of the type specified by the generic parameter
        /// </summary>
        /// <param name="services">The collection of services</param>
        /// <param name="lifetime">The lifetime of the validators. The default is scoped (per-request in web applications)</param>
        /// <param name="includeInternalTypes">Include internal validators. The default is false.</param>
        /// <returns></returns>
        public static IServiceCollection AddValidatorsFromAssemblyContaining<T>(this IServiceCollection services,
            ServiceLifetime lifetime = ServiceLifetime.Scoped, bool includeInternalTypes = false)
            => services.AddValidatorsFromAssembly(typeof(T).Assembly, lifetime, includeInternalTypes);

        /// <summary>
        /// Adds all validators in the assembly of the specified type
        /// </summary>
        /// <param name="services">The collection of services</param>
        /// <param name="type">The type whose assembly to scan</param>
        /// <param name="lifetime">The lifetime of the validators. The default is scoped (per-request in web applications)</param>
        /// <param name="includeInternalTypes">Include internal validators. The default is false.</param>
        /// <returns></returns>
        public static IServiceCollection AddValidatorsFromAssemblyContaining(this IServiceCollection services,
            Type type, ServiceLifetime lifetime = ServiceLifetime.Scoped, bool includeInternalTypes = false)
            => services.AddValidatorsFromAssembly(type.Assembly, lifetime, includeInternalTypes);

        /// <summary>
        /// Helper method to register a validator from an AssemblyScanner result
        /// </summary>
        /// <param name="services">The collection of services</param>
        /// <param name="scanResult">The scan result</param>
        /// <param name="lifetime">The lifetime of the validators. The default is scoped (per-request in web applications)</param>
        /// <returns></returns>
        public static IServiceCollection AddScanResult(this IServiceCollection services,
            AssemblyScanner.AssemblyScanResult scanResult, ServiceLifetime lifetime)
        {
            services.Add(new ServiceDescriptor(
                serviceType: scanResult.InterfaceType,
                implementationType: scanResult.ValidatorType,
                lifetime: lifetime));
            
            services.Add(new ServiceDescriptor(
                serviceType: scanResult.ValidatorType,
                implementationType: scanResult.ValidatorType,
                lifetime: lifetime));

            return services;
        }
    }
}