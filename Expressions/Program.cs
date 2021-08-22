using System;
using Expressions.Classes;
using Expressions.Classes.Calculation;
using Expressions.Libs.Validator;

namespace Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            // var greetFunc = GreetingExpression.Create();
            // Console.WriteLine("Greet result: {0}", greetFunc("Shpek"));
            //
            // var multiply = Calculation.Multiply.Of<double>(4, 5);
            // Console.WriteLine("Multiply result: {0}", multiply);

            var dto = new Dto { Id = 18, Name = "Oleg" };

            IValidator<Dto> validator = new Validator<Dto>();
            validator
                .AddValidation(x => x.Id, o => o > 17)
                .AddValidation(x => x.Name, o => !string.IsNullOrEmpty(o));

            bool isValid = validator.Validate(dto);
            Console.WriteLine(isValid);
        }
    }

    public class Dto
    {
        public int Id { get; set; }
        public string Name { get; set;  }
    }
}
