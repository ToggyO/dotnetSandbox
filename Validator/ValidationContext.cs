using System.Collections.Generic;

using Expressions.Libs.Validator.Results;

namespace Validator
{
    /// <summary>
    /// Validation context.
    /// </summary>
    /// <typeparam name="T">Type of instance to validate.</typeparam>
    public class ValidationContext<T> : IValidationContext, IHasFailures
    {
        /// <inheritdoc cref="IValidationContext.InstanceToValidate"/>.
        object IValidationContext.InstanceToValidate => InstanceToValidate;
        
        /// <inheritdoc cref="IHasFailures.Failures"/>.
        List<ValidationFailure> IHasFailures.Failures { get; }
        
        /// <summary>
        /// Gets or sets a collection of validation errors <see cref="ValidationFailure"/>.
        /// </summary>
        internal List<ValidationFailure> Failures { get; }
        
        public ValidationContext(T instanceToValidate)
            : this(instanceToValidate, new List<ValidationFailure>())
        {}

        public ValidationContext(T instanceToValidate, List<ValidationFailure> errors)
        {
            InstanceToValidate = instanceToValidate;
            Failures = errors;
        }

        /// <summary>
        /// The object currently being validated.
        /// </summary>
        public T InstanceToValidate { get; }
    }
}