using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Validator
{
    /// <summary>
    /// Class that can be used to find all the validators from a collection of types.
    /// </summary>
    public class AssemblyScanner : IEnumerable<AssemblyScanner.AssemblyScanResult>
    {
        /// <summary>
        /// Assembly types.
        /// </summary>
        private readonly IEnumerable<Type> _types;

        public AssemblyScanner(IEnumerable<Type> types) => _types = types;

        /// <summary>
        /// Finds all the validators in the specified assembly.
        /// </summary>
        public static AssemblyScanner FindValidatorsInAssembly(Assembly assembly, bool includeInternalTypes = false)
            => new AssemblyScanner(includeInternalTypes ? assembly.GetTypes() : assembly.GetExportedTypes());

        /// <summary>
        /// Finds all the validators in the specified assemblies
        /// </summary>
        public static AssemblyScanner FindValidatorsInAssemblies(
            IEnumerable<Assembly> assemblies, bool includeInternalTypes)
        {
            var types = assemblies
                .SelectMany(x => includeInternalTypes ? x.GetTypes() : x.GetExportedTypes())
                .Distinct();
            return new AssemblyScanner(types);
        }

        /// <summary>
        /// Finds all the validators in the assembly containing the specified type.
        /// </summary>
        public static AssemblyScanner FindValidatorsInAssemblyContaining<T>()
            => FindValidatorsInAssembly(typeof(T).Assembly);

        /// <summary>
        /// Finds all the validators in the assembly containing the specified type.
        /// </summary>
        public static AssemblyScanner FindValidatorsInAssemblyContaining(Type type)
            => FindValidatorsInAssembly(type.Assembly);

        /// <summary>
        /// Performs the specified action to all of the assembly scan results.
        /// </summary>
        public void ForEach(Action<AssemblyScanResult> action)
        {
            foreach (var result in this)
                action(result);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public IEnumerator<AssemblyScanResult> GetEnumerator()
            => Execute().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
        /// <summary>
        /// Search types, implemented from <see cref="IValidator{T}"/>.
        /// </summary>
        /// <returns>Collection of <see cref="AssemblyScanResult"/>.</returns>
        private IEnumerable<AssemblyScanResult> Execute()
        {
            Type openGenericType = typeof(IValidator<>);
            return from type in _types
                where !type.IsAbstract && !type.IsGenericTypeDefinition
                let matchingInterface = type
                    .GetInterfaces()
                    .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == openGenericType)
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