using System.Collections.Generic;
using System.Linq;

namespace Expressions.Libs.Validator.Results
{
    public class ValidationResult
    {
        private readonly IList<ValidationFailure> _errors;

        public virtual bool IsValid => _errors.Count == 0;

        public IList<ValidationFailure> Errors => _errors;

        public ValidationResult() => _errors = new List<ValidationFailure>();

        public ValidationResult(IEnumerable<ValidationFailure> failures) =>
            _errors = failures.Where(failure => failure != null).ToList();

        internal ValidationResult(IList<ValidationFailure> errors) => _errors = errors;
    }
}