using System;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class InjectAttribute : Attribute
    {
        public ServiceLifetime ServiceLifetime { get; }
        
        public Type ExplicitInterface { get;  }

        public InjectAttribute(ServiceLifetime serviceLifetime, Type explicitInterface = null)
        {
            ServiceLifetime = serviceLifetime;

            if (explicitInterface != null && !explicitInterface.IsInterface)
                throw new ArgumentException(nameof(explicitInterface));

            ExplicitInterface = explicitInterface;
        }
    }
}