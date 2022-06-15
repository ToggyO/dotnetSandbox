using System;
using System.Linq;
using System.Reflection;

using AlgorithmsAndDataStructures.Common.Interfaces;

namespace AlgorithmsAndDataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var testsCollection = from t in Assembly.GetExecutingAssembly().ExportedTypes
                where !t.IsAbstract && !t.IsInterface
                                    && typeof(ITest).IsAssignableFrom(t)
                select t;

            foreach (var test in testsCollection)
            {
                var instance = Activator.CreateInstance(test);
                ((ITest) instance).Run();
            }
        }
    }
}
