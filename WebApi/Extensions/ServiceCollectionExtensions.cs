using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Attributes;

namespace WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterServicesFromAssembly<T>(this IServiceCollection services)
        {
            var injectableTypes = typeof(T).Assembly.DefinedTypes
                .Where(x => x.GetCustomAttributes(typeof(InjectAttribute), false)
                    .FirstOrDefault() != null && x.IsClass);

            foreach (var injectableType in injectableTypes)
            {
                var injectAttributeData = injectableType
                    .GetCustomAttributes(typeof(InjectAttribute), false).First() as InjectAttribute;

                if (injectAttributeData.ExplicitInterface != null)
                {
                    services.Add(new ServiceDescriptor(
                        injectAttributeData.ExplicitInterface,
                        injectableType,
                        injectAttributeData.ServiceLifetime));
                }
                else
                {
                    foreach (var implementedInterface in injectableType.ImplementedInterfaces)
                    {
                        services.Add(new ServiceDescriptor(
                            implementedInterface,
                            injectableType,
                            injectAttributeData.ServiceLifetime));
                    }
                }
            }
        }
    }
}