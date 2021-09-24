using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Validator
{
    public class AssemblyScanner
    {
        public IEnumerable<AssemblyScanResult> Execute()
        {
            Type openGenericType = typeof(IValidator<>);
            return from type in Assembly.GetExecutingAssembly().DefinedTypes
                where !type.IsAbstract && !type.IsGenericTypeDefinition
                    let matchingInterface = type.GetInterfaces()
                        .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == openGenericType)
                        .FirstOrDefault()
                where matchingInterface != null
                select new AssemblyScanResult(matchingInterface, type);
        }
        
        /// <summary>
        /// Result of performing a scan.
        /// </summary>
        public class AssemblyScanResult
        {
            /// <summary>
            /// Creates an instance of an AssemblyScanResult.
            /// </summary>
            public AssemblyScanResult(Type interfaceType, Type validatorType)
            {
                InterfaceType = interfaceType;
                ValidatorType = validatorType;
            }

            /// <summary>
            /// Validator interface type, eg IValidator{Foo};
            /// </summary>
            public Type InterfaceType { get; private set; }

            /// <summary>
            /// Concrete type that implements the InterfaceType, eg FooValidator.
            /// </summary>
            public Type ValidatorType { get; private set; }
        }
    }
}