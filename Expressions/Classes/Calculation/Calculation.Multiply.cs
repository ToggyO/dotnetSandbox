using System;
using System.Linq.Expressions;

namespace Expressions.Classes.Calculation
{
    public static partial class Calculation
    {
        public static class Multiply
        {
            private static class Impl<T>
            {
                public static Func<T, T, T> Of { get; }

                static Impl()
                {
                    var param1 = Expression.Parameter(typeof(T));
                    var param2 = Expression.Parameter(typeof(T));
                    
                    var writeLineMethod = typeof(Console)
                        .GetMethod(nameof(Console.WriteLine), new[] { typeof(string), typeof(Object), typeof(Object) });
                    
                    var consoleArg1 = Expression.Convert(param1, typeof(Object));
                    var consoleArg2 = Expression.Convert(param2, typeof(Object));

                    var paramsToConsole = Expression.Call(
                        writeLineMethod,
                        Expression.Constant("{0} * {1}"),
                        consoleArg1,
                        consoleArg2);

                    var leftOperand = Expression.Convert(param1, typeof(T));
                    var rightOperand = Expression.Convert(param2, typeof(T));

                    var multiplyOperation = Expression.Multiply(leftOperand, rightOperand);

                    var block = Expression.Block(
                        typeof(T),
                        paramsToConsole,
                        multiplyOperation);

                    var lambda = Expression.Lambda<Func<T, T, T>>(block, param1, param2);

                    Of = lambda.Compile();
                }
            }

            public static T Of<T>(T a, T b) => Impl<T>.Of(a, b);
        }
    }
}