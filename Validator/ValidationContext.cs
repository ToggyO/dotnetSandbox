using System;
using System.Collections.Generic;

using Validator.Internal;
using Validator.Results;

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
        IList<ValidationFailure> IHasFailures.Failures { get; }
        
        /// <summary>
        /// Gets or sets a collection of validation errors <see cref="ValidationFailure"/>.
        /// </summary>
        internal List<ValidationFailure> Failures { get; }
        
        public ValidationContext(T instanceToValidate)
            : this(instanceToValidate, new List<ValidationFailure>())
        {}

        public ValidationContext(T instanceToValidate, List<ValidationFailure> errors)
            : this(instanceToValidate, errors, ValidatorOptions.Global.MessageFormatterFactory())
        { }

        internal ValidationContext(
            T instanceToValidate, List<ValidationFailure> errors, MessageFormatter messageFormatter)
        {
            InstanceToValidate = instanceToValidate;
            Failures = errors;
            MessageFormatter = messageFormatter;
        }

        /// <summary>
        /// The object currently being validated.
        /// </summary>
        public T InstanceToValidate { get; }

        /// <summary>
		/// The full name of the current property being validated.
		/// If accessed inside a child validator, this will include the parent's path too.
		/// </summary>
		public string PropertyName { get; private set; }
        
        /// <summary>
        /// The message formatter used to construct error messages.
        /// </summary>
        public MessageFormatter MessageFormatter { get; }

        /// <summary>
        /// Adds a new validation failure.
        /// </summary>
        /// <param name="failure">The failure to add.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddFailure(ValidationFailure failure)
        {
            if (failure == null) throw new ArgumentNullException(nameof(failure), "A failure must be specified when calling AddFailure");
            Failures.Add(failure);
        }

        /// <summary>
        /// Adds a new validation failure for the specified property.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <param name="errorMessage">The error message.</param>
        public void AddFailure(string propertyName, string errorMessage)
        {
            errorMessage.Guard("An error message must be specified when calling AddFailure.", nameof(errorMessage));
            AddFailure(new ValidationFailure(propertyName, errorMessage));
        }

        /// <summary>
        /// Adds a new validation failure for the specified message.
        /// The failure will be associated with the current property being validated.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        public void AddFailure(string errorMessage)
        {
            errorMessage.Guard("An error message must be specified when calling AddFailure.", nameof(errorMessage));
            AddFailure(new ValidationFailure(PropertyName, errorMessage));
        }

        public void InitializeForPropertyValidator(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
}