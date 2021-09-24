using System;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Attributes;

namespace WebApi.Services
{
    public interface IService2
    {
        int Subtract(int a, int b);
    }

    [Inject(ServiceLifetime.Transient, typeof(IService2))]
    public class Service2 : IService2
    {
        public Service2(IService1 service1)
        {
            int temp = service1.Add(5, 6);
            int result = Subtract(temp, 1);
            Console.WriteLine(result);
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }
    }
}