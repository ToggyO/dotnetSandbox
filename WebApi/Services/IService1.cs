using Microsoft.Extensions.DependencyInjection;
using WebApi.Attributes;

namespace WebApi.Services
{
    public interface IService1
    {
        int Add(int a, int b);
    }

    [Inject(serviceLifetime: ServiceLifetime.Transient)]
    public class Service1 : IService1
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}