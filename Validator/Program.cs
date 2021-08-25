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

            var validator = new Validator<Dto>();

            validator.AddValidationFor(x => x.Name).NotNull();

            validator.Validate(dto);
        }
    }

    class Dto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
