using System;

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
    }
}