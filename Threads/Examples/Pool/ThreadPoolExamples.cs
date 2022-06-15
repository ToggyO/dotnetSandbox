using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads.Examples.Pool
{
    internal class ThreadPoolExamples
    {
        internal class ExampleOne
        {
            internal static void Run()
            {
                Console.WriteLine("Main thread: start");
                ThreadPool.QueueUserWorkItem(ComputeOp, 69);

                Console.WriteLine("Main thread: doing other work...");
                Thread.Sleep(10000);

                Console.WriteLine("Hit <Enter> to end this program...");
                Console.ReadLine();
            }

            private static void ComputeOp(object state)
            {
                Console.WriteLine("In ComputeOp: state={0}", state);
                Thread.Sleep(1000);
            }
        }
    }
}
