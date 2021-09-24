using Validator.Internal;

namespace Validator
{
    /// <summary>
    /// Default options that can be used to configure a validator.
    /// </summary>
    public static class DefaultValidatorOptions
    {
        /// <summary>
        /// Specifies a custom error message to use when validation fails. Only applies to the rule that directly precedes it.
        /// </summary>
        /// <param name="ruleBuilder">The current rule.</param>
        /// <param name="message">Error message to display.</param>
        /// <returns></returns>
        public static IRuleBuilder<T, TProperty> WithMessage<T, TProperty>(
            this IRuleBuilder<T, TProperty> ruleBuilder, string message)
        {
            message.Guard("A message must be specified when calling WithMessage.", nameof(message));
            ((IRuleBuilderInternal<T, TProperty>) ruleBuilder).Rule.Current.SetErrorMessage(message);
            return ruleBuilder;
        }

        /// <summary>
        /// Specifies a custom error code to use if validation fails.
        /// </summary>
        /// <param name="ruleBuilder">The current rule.</param>
        /// <param name="errorCode">The error code to use.</param>
        /// <returns></returns>
        public static IRuleBuilder<T, TProperty> WithErrorCode<T, TProperty>(
            this IRuleBuilder<T, TProperty> ruleBuilder, string errorCode)
        {
            errorCode.Guard("A error code must be specified when calling WithErrorCode.", nameof(errorCode));
            ((IRuleBuilderInternal<T, TProperty>) ruleBuilder).Rule.Current.ErrorCode = errorCode;
            return ruleBuilder;
        }
    }
}