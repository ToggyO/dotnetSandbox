using System;
using System.Linq.Expressions;
using System.Reflection;

using Validator.Internal;
using Validator.Resources;
using Validator.Validators;

namespace Validator
{
    /// <summary>
    /// Configuration options for validators.
    /// </summary>
    public class ValidatorConguration
    {
        private Func<MessageFormatter> _messageFormatterFactory = () => new MessageFormatter();

        private Func<MemberInfo, LambdaExpression, string> _propertyNameResolver = DefaultPropertyNameResolver;

        private Func<IPropertyValidator, string> _errorCodeResolver = DefaultErrorCodeResolver;

        private IMessageManager _messageManager = new MessageManager();

        /// <summary>
        /// Specifies a factory for creating MessageFormatter instances.
        /// </summary>
        public Func<MessageFormatter> MessageFormatterFactory
        {
            get => _messageFormatterFactory;
            set => _messageFormatterFactory = value ?? (() => new MessageFormatter());
    }
        
        /// <summary>
		/// Pluggable logic for resolving property names.
		/// </summary>
        public Func<MemberInfo, LambdaExpression, string> PropertyNameResolver
        {
            get => _propertyNameResolver;
            set => _propertyNameResolver = value ?? DefaultPropertyNameResolver;
        }

        /// <summary>
		/// Pluggable resolver for default error codes.
		/// </summary>
        public Func<IPropertyValidator, string> ErrorCodeResolver
        {
            get => _errorCodeResolver;
            set => _errorCodeResolver = value ?? DefaultErrorCodeResolver;
        }

        /// <summary>
		/// Default message manager.
		/// </summary>
        public IMessageManager MessageManager
        {
            get => _messageManager;
            set => _messageManager = value ?? throw new ArgumentNullException(nameof(value));
        }


        // TODO: add retreiving property name from expression property chain 
        private static string DefaultPropertyNameResolver(MemberInfo memberInfo, LambdaExpression expression) => memberInfo?.Name;

        private static string DefaultErrorCodeResolver(IPropertyValidator validator) => validator?.Name;
    }

    /// <summary>
	/// Validator runtime options
	/// </summary>
    public static class ValidatorOptions
    {
        /// <summary>
		/// Global configuration for all validators.
		/// </summary>
        public static ValidatorConguration Global => new ();
    }
}