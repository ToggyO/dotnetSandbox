using System;
using System.Linq.Expressions;

namespace Expressions.Classes
{
    public static class GreetingExpression
    {
        public static Func<string, string> Create()
        {
            var parameter = Expression.Parameter(typeof(string), "name");
            var concatMethod = typeof(string)
                .GetMethod(nameof(string.Concat), new [] { typeof(string), typeof(string) });
            var result = Expression.Call(
                concatMethod,
                Expression.Constant("Greeting, "),
                parameter);
            var lambda = Expression.Lambda<Func<string, string>>(result, parameter);
            Console.WriteLine(lambda.ToString());
            return lambda.Compile();
        }
    }
}