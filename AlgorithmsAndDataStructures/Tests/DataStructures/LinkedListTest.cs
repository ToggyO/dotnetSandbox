using System;
using AlgorithmsAndDataStructures.Common.Classes;
using AlgorithmsAndDataStructures.Common.Interfaces;
using AlgorithmsAndDataStructures.DataStructures.LinkedList;

namespace AlgorithmsAndDataStructures.Tests.DataStructures
{
    public class LinkedListTest : ITest
    {
        public void Run()
        {
            Console.WriteLine("/**************** Linked List ****************/");
            
            var linkedList = new LinkedList<User>();

            var zhenya = new User { Name = "Zhenya", Age = 69 };
            var nastya = new User { Name = "Nastya", Age = 28 };
            var oleg = new User { Name = "Oleg", Age = 29 };
            var alina = new User { Name = "ALina", Age = 31 };
            var sergey = new User { Name = "Sergey", Age = 29 };
            
            linkedList.Append(oleg);
            linkedList.Append(alina);
            linkedList.Append(sergey);
            linkedList.Prepend(nastya);

            Console.WriteLine($"List contains Zhenya: {linkedList.Contains(zhenya)}");
            Console.WriteLine($"List contains Nastya: {linkedList.Contains(nastya)}");

            Console.WriteLine("List state after appending:");
            ShowListItems(linkedList);
            
                        
            bool isAppendingSuccessful = linkedList.TryAppendAfter(zhenya, sergey);
            Console.WriteLine($"Appending after result: {isAppendingSuccessful}");
            
            Console.WriteLine("List state after try append:");
            ShowListItems(linkedList);
            
            linkedList.Remove(oleg);
            linkedList.Remove(alina);
            linkedList.Remove(sergey);
            linkedList.Remove(nastya);
            
            Console.WriteLine("List state after removing:");
            ShowListItems(linkedList);
            Console.WriteLine();
        }

        private void ShowListItems(LinkedList<User> linkedList)
        {
            foreach (var data in linkedList)
            {
                Console.WriteLine($"Name: {data.Name}, Age={data.Age}");
            }

            Console.WriteLine($"Items count: {linkedList.Count}");
        }
    }
}