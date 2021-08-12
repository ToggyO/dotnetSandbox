using System;
using Expressions.Classes;
using Expressions.Classes.Calculation;

namespace Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            var greetFunc = GreetingExpression.Create();
            Console.WriteLine("Greet result: {0}", greetFunc("Shpek"));

            var multiply = Calculation.Multiply.Of<double>(4, 5);
            Console.WriteLine("Multiply result: {0}", multiply);
        }
    }
}
