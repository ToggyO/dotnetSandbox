using System;

using Validator.Resources;

namespace Validator.Internal
{
    /// <summary>
    /// Represents internal extensions.
    /// </summary>
    internal static class ExtensionsInternal
    {
        /// <summary>
        /// Check if value is null.
        /// </summary>
        /// <param name="obj">Object to check.</param>
        /// <param name="message">Error message.</param>
        /// <param name="paramName">Name of a parameter.</param>
        /// <exception cref="ArgumentNullException">Exception.</exception>
        internal static void Guard(this object obj, string message, string paramName)
        {
            if (obj == null) 
                throw new ArgumentNullException(paramName, message);
        }

        /// <summary>
        ///  Retrieves string from the <see cref="IMessageManager"/>.
		///  If an ErrorCode is defined, the error code is used as the key.
		///  If no ErrorCode is defined then the fallback key is used instead.
        /// </summary>
        /// <param name="messageManager">Instance of <see cref="IMessageManager"/>.</param>
        /// <param name="errorCode">Error code.</param>
        /// <param name="fallbackKey">The fallback key, if no errorCode is available.</param>
        /// <returns>The error message template.</returns>
        internal static string ResolveErrorMessageUsingErrorCode(
            this IMessageManager messageManager, string errorCode, string fallbackKey)
        {
            if (errorCode != null)
            {
                string result = messageManager.GetString(errorCode);

                if (!string.IsNullOrEmpty(result))
                    return result;
            }

            return messageManager.GetString(fallbackKey);
        }
    }
}