using Validator;
using WebApi.Dto.Test;

namespace WebApi.Validators
{
    public class TestDtoValidator : AbstractValidator<TestDTO>
    {
        public TestDtoValidator()
        {
            AddValidationFor(x => x.Name)
                .NotNull()
                .WithMessage("AAAA MESSAGE!")
                .WithErrorCode("not_null");
            
            AddValidationFor(x => x.Name)
                .NotNull()
                .WithMessage("Name is required.")
                .WithErrorCode("validation.reuqired");
        }
    }
}