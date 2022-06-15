using System;
using AlgorithmsAndDataStructures.Common.Classes;
using AlgorithmsAndDataStructures.Common.Interfaces;
using AlgorithmsAndDataStructures.DataStructures.LinkedList;

namespace AlgorithmsAndDataStructures.Tests.DataStructures
{
    public class DoubleLinkedListTest : ITest
    {
        public void Run()
        {
            Console.WriteLine("/**************** Double Linked List ****************/");

            var doubleLinkedList = new DoubleLinkedList<User>();
            
            var zhenya = new User { Name = "Zhenya", Age = 69 };
            var nastya = new User { Name = "Nastya", Age = 28 };
            var oleg = new User { Name = "Oleg", Age = 29 };
            var alina = new User { Name = "ALina", Age = 31 };
            var sergey = new User { Name = "Sergey", Age = 29 };
            
            doubleLinkedList.Append(oleg);
            doubleLinkedList.Append(alina);
            doubleLinkedList.Append(zhenya);
            doubleLinkedList.Append(sergey);
            doubleLinkedList.Prepend(nastya);

            Console.WriteLine($"List contains Zhenya: {doubleLinkedList.Contains(zhenya)}");
            Console.WriteLine($"List contains Nastya: {doubleLinkedList.Contains(nastya)}");

            Console.WriteLine("List state after appending:");
            ShowListItems(doubleLinkedList);
            
            bool isAppendingSuccessful = doubleLinkedList.TryAppendAfter(zhenya, sergey);
            Console.WriteLine($"Appending after result: {isAppendingSuccessful}");
            
            Console.WriteLine("List state after try append:");
            ShowListItems(doubleLinkedList);
            
            doubleLinkedList.Remove(oleg);
            doubleLinkedList.Remove(alina);
            doubleLinkedList.Remove(sergey);
            doubleLinkedList.Remove(nastya);
            
            Console.WriteLine("List state after removing:");
            ShowListItems(doubleLinkedList);
            Console.WriteLine();
        }
        
        private void ShowListItems(DoubleLinkedList<User> doubleLinkedList)
        {
            foreach (var data in doubleLinkedList)
            {
                Console.WriteLine($"Name: {data.Name}, Age={data.Age}");
            }

            Console.WriteLine($"Items count: {doubleLinkedList.Count}");
        }
    }
}