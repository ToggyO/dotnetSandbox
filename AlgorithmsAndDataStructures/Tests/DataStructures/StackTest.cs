using System;
using AlgorithmsAndDataStructures.Common.Classes;
using AlgorithmsAndDataStructures.Common.Interfaces;
using AlgorithmsAndDataStructures.DataStructures.Stack;

namespace AlgorithmsAndDataStructures.Tests.DataStructures
{
    public class StackTest : ITest
    {
        public void Run()
        {
            Console.WriteLine("/**************** Stack ****************/");
            
            var stack = new Stack<User>();

            var zhenya = new User { Name = "Zhenya", Age = 69 };
            var nastya = new User { Name = "Nastya", Age = 28 };
            var oleg = new User { Name = "Oleg", Age = 29 };
            var alina = new User { Name = "ALina", Age = 31 };
            var sergey = new User { Name = "Sergey", Age = 29 };
            
            stack.Push(zhenya);
            stack.Push(nastya);
            stack.Push(oleg);
            stack.Push(alina);
            stack.Push(sergey);
            
            Console.WriteLine("Stack state after appending:");
            ShowListItems(stack);

            var first = stack.Peek();
            Console.WriteLine($"First item in stack: {first.Name}, {first.Age}");

            stack.Pop();
            stack.Pop();
            stack.Pop();
            
            Console.WriteLine("Stack state after removing:");
            ShowListItems(stack);
            Console.WriteLine();
        }

        private void ShowListItems(Stack<User> stack)
        {
            foreach (var data in stack)
            {
                Console.WriteLine($"Name: {data.Name}, Age={data.Age}");
            }

            Console.WriteLine($"Items count: {stack.Count}");
        }
    }
}