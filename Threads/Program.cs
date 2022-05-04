using System;
using System.Threading;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
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
}
