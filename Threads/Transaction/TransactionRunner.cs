using System;
using System.Threading.Tasks;

namespace Threads.Transaction
{
    public class TransactionRunner
    {
        public static void Run()
        {
            var john = new Person
            {
                Id = 1,
                Name = "John",
                Balance = 1200
            };

            var clark = new Person
            {
                Id = 2,
                Name = "Clark",
                Balance = 600
            };

            // var transfer1 = Task.Run(() => Person.Transfer(john, clark, 300));
            // var transfer2 = Task.Run(() => Person.Transfer(clark, john, 600));
            var transfer1= Person.TransferAsync(john, clark, 300);
            var transfer2 = Person.TransferAsync(clark, john, 600);

            Task.WaitAll(transfer1, transfer2);
            Console.WriteLine("Done");
        }
    }
}