using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Validator.Internal
{
    /// <summary>
    /// Assists in the construction of validation messages.
    /// </summary>
    public class MessageFormatter
    {
        private readonly IDictionary<string, object> _placeholderValues = new Dictionary<string, object>(2);
        
        private static readonly Regex _keyRegex = new Regex("{([^{}:]+)(?::([^{}]+))?}", RegexOptions.Compiled);

        /// <summary>
        /// Default Property Name placeholder.
        /// </summary>
        public const string PropertyName = "PropertyName";

        /// <summary>
        /// Default Property Value placeholder.
        /// </summary>
        public const string PropertyValue = "PropertyValue";

        /// <summary>
        /// Additional placeholder values
        /// </summary>
        public IDictionary<string, object> PlaceholderValues => _placeholderValues;

        /// <summary>
        /// Adds a value for a validation message placeholder.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public MessageFormatter AppendArgument(string name, object value)
        {
            _placeholderValues[name] = value;
            return this;
        }

        /// <summary>
        /// Appends a property name to the message.
        /// </summary>
        /// <param name="name">The name of the property</param>
        /// <returns></returns>
        public MessageFormatter AppendPropertyName(string name)
            => AppendArgument(PropertyName, name);

        /// <summary>
        /// Appends a property value to the message.
        /// </summary>
        /// <param name="value">The value of the property</param>
        /// <returns></returns>
        public MessageFormatter AppendPropertyValue(object value)
            => AppendArgument(PropertyValue, value);

        /// <summary>
        /// Constructs the final message from the specified template.
        /// </summary>
        /// <param name="messageTemplate">Message template</param>
        /// <returns>The message with placeholders replaced with their appropriate values</returns>
        public virtual string BuildMessage(string messageTemplate)
            => _keyRegex.Replace(messageTemplate, m =>
            {
                var key = m.Groups[1].Value;

                if (!_placeholderValues.TryGetValue(key, out var value))
                    return m.Value;
                
                var format = m.Groups[2].Success // Format specified?
                    ? $"{{0:{m.Groups[2].Value}}}"
                    : null;

                return format == null
                    ? value.ToString()
                    : string.Format(format, value);
            });

        internal void Reset() => _placeholderValues.Clear();
    }
}