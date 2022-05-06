using System;

namespace Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            var dto = new Dto
            {
                Id = 0,
                Name = null,
                Description = "",
            };

            // var assemblyScanResults = new AssemblyScanner().Execute();
            //
            // foreach (var result in assemblyScanResults)
            // {
            //     Console.WriteLine(result.InterfaceType.Name);
            //     Console.WriteLine(result.ValidatorType.Name);
            // }

            var validator = new DtoValidator();
            
            var context = new ValidationContext<Dto>(dto);
            var validationResult = validator.Validate(context);
            
            foreach (var error in validationResult.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
                Console.WriteLine(error.ErrorCode);
            }

            // IValidator<Dto> validator = new Validator<Dto>();

            // validator.AddValidationFor(x => x.Name)
            //     .NotNull()
            //     .WithMessage("AAAA MESSAGE!")
            //     .WithErrorCode("not_null");

            // var context = new ValidationContext<Dto>(dto);
            // var result = validator.Validate(context);
            //
            // foreach (var error in result.Errors)
            // {
            //     Console.WriteLine(error.ErrorMessage);
            //     Console.WriteLine(error.ErrorCode);
            // }
        }
    }

    public class Dto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }

    public class DtoValidator : AbstractValidator<Dto>
    {
        public DtoValidator()
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
