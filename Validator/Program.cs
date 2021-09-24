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

            IValidator<Dto> validator = new Validator<Dto>();

            validator.AddValidationFor(x => x.Name)
                .NotNull()
                .WithMessage("AAAA MESSAGE!")
                .WithErrorCode("not_null");

            var context = new ValidationContext<Dto>(dto);
            var result = validator.Validate(context);
            
            foreach (var error in result.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
                Console.WriteLine(error.ErrorCode);
            }
        }
    }

    class Dto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
