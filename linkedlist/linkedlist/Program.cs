using System;

namespace linkedlist
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<string> linkedList = new DoublyLinkedList<string>();
            
            linkedList.Add("Bob");// добавление элементов
            foreach (var list in linkedList)
            {
                Console.WriteLine(list);
            }
            Console.WriteLine("-------------------");
            linkedList.Add("Bill");
            foreach (var list in linkedList)
            {
                
                Console.WriteLine(list);

            }
            Console.WriteLine("-------------------");
            linkedList.Add("Tom");
            foreach (var list in linkedList)
            {
                
                Console.WriteLine(list);
            }
            Console.WriteLine("-------------------");
            linkedList.Add("Bravo");
            foreach (var list in linkedList)
            {
                
                Console.WriteLine(list);
            }
            Console.WriteLine("-------------------");
            linkedList.AddAt("Kate", 3);// добавление элемента по индексу
            foreach (var list in linkedList)
            {
                
                Console.WriteLine(list);
            }
            Console.WriteLine("-------------------");
            linkedList.RemoveAt(2);// удаление элемента по индексу

            foreach (var list in linkedList)
            {
                
                Console.WriteLine(list);
            }
            Console.ReadKey();
        }
    }
}
