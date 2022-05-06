using System;
using System.Threading;

namespace Threads.Examples.Simple
{
    internal static class SimpleThreadExamples
    {
        internal static class ExampleOne
        {
            internal static void Run(string[] args)
            {
                Console.WriteLine("Main thread - start");
                var worker = new Thread(DoWork);
                worker.Start(5);

                Console.WriteLine("Main thread - do another heavy work");
                Thread.Sleep(5000);

                worker.Join();

                Console.ReadLine();
                Console.WriteLine("Main thread - complete");
            }

            private static void DoWork(object state)
            {
                Console.WriteLine("DoWork current state: {0}", state);
                Thread.Sleep(1000);
            }
        }

        internal static class ExampleTwo
        {
            internal static void Run()
            {
                var thread = new Thread(Worker);

                thread.IsBackground = true;

                thread.Start();

                thread.IsBackground = false;

                Console.WriteLine("Returning from Run");
            }

            private static void Worker(object state)
            {
                Thread.Sleep(10000);
                Console.WriteLine("Returnin from Worker");
            }
        }
    }
}
