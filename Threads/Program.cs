using System;
using System.Threading;
using System.Threading.Tasks;
using Threads.Examples.Simple;
using Threads.Examples.Pool;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            // SimpleThreadExamples.ExampleTwo.Run();
            // ThreadPoolExamples.ExampleOne.Run();
            Transaction.TransactionRunner.Run();
        }
    }
}
