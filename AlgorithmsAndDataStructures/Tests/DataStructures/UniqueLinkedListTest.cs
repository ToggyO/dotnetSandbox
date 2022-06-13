using System;
using AlgorithmsAndDataStructures.Common.Classes;
using AlgorithmsAndDataStructures.Common.Interfaces;
using AlgorithmsAndDataStructures.DataStructures.LinkedList;

namespace AlgorithmsAndDataStructures.Tests.DataStructures
{
    public class UniqueLinkedListTest : ITest
    {
        public void Run()
        {
            Console.WriteLine("/**************** Unique Linked List ****************/");

            var uniqueLinkedList = new UniqueLinkedList<User>();
            
            var zhenya = new User { Name = "Zhenya", Age = 69 };
            var nastya = new User { Name = "Nastya", Age = 28 };
            var oleg = new User { Name = "Oleg", Age = 29 };
            var alina = new User { Name = "ALina", Age = 31 };
            var sergey = new User { Name = "Sergey", Age = 29 };
            
            uniqueLinkedList.Append(oleg);
            uniqueLinkedList.Append(alina);
            // uniqueLinkedList.Append(zhenya);
            uniqueLinkedList.Append(sergey);
            uniqueLinkedList.Prepend(nastya);

            Console.WriteLine($"List contains Zhenya: {uniqueLinkedList.Contains(zhenya)}");
            Console.WriteLine($"List contains Nastya: {uniqueLinkedList.Contains(nastya)}");

            Console.WriteLine("List state after appending:");
            ShowListItems(uniqueLinkedList);
            
            bool isAppendingSuccessful = uniqueLinkedList.TryAppendAfter(zhenya, sergey);
            Console.WriteLine($"Appending after result: {isAppendingSuccessful}");
            
            Console.WriteLine("List state after try append:");
            ShowListItems(uniqueLinkedList);
            
            uniqueLinkedList.Remove(oleg);
            uniqueLinkedList.Remove(alina);
            uniqueLinkedList.Remove(sergey);
            uniqueLinkedList.Remove(nastya);
            
            Console.WriteLine("List state after removing:");
            ShowListItems(uniqueLinkedList);
            Console.WriteLine();
        }
        
        private void ShowListItems(UniqueLinkedList<User> linkedList)
        {
            foreach (var data in linkedList)
            {
                Console.WriteLine($"Name: {data.Name}, Age={data.Age}");
            }

            Console.WriteLine($"Items count: {linkedList.Count}");
        }
    }
}