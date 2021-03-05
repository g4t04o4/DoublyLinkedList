using System;
using System.Collections.Generic;

namespace DoublyLinkedList
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var list = new ListRandom();

            Console.WriteLine(list.IsEmpty);

            list.AddLast("first data");
            list.AddLast("second data");
            list.AddLast("third data");
            list.AddLast("fourth data");
            list.AddFirst("zero data");

            list.Display();

            Console.WriteLine(list.Contains("third data"));
            list.Remove("third data");
            Console.WriteLine(list.Contains("third data"));

            Console.WriteLine(list.IsEmpty);
            list.Clear();
            Console.WriteLine(list.IsEmpty);
        }
    }
}