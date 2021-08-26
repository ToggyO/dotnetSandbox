namespace Validator.Results
{
    // TODO: add description
    public class ValidationFailure
    {
        public string PropertyName { get; set; }

        public string ErrorMessage { get; set; }
  
        public object AttemptedValue { get; set; }

        public string ErrorCode { get; set; }

        public ValidationFailure(string propertyName, string errorMessage)
            : this(propertyName, errorMessage, null)
        {}

        public ValidationFailure(string propertyName, string errorMessage, object attemptedValue)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
            AttemptedValue = attemptedValue;
        }
    }
}