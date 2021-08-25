namespace Validator.Internal
{
    /// <summary>
    /// An individual component within a rule with a validator attached.
    /// </summary>
    public interface IRuleComponent
    {
        /// <summary>
        /// The error code associated with this rule component.
        /// </summary>
        string ErrorCode { get; set; }

        /// <summary>
        /// The error message associated with this rule component.
        /// </summary>
        string ErrorMessage { get; set; }
    }
}