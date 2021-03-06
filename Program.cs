using System;
using System.Collections.Generic;
using System.IO;

namespace DoublyLinkedList
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var list = new ListRandom();

            list.AddLast("first data");
            list.AddLast("second data");
            list.AddLast("third data");
            list.AddLast("fourth data");
            list.AddFirst("zero data");

            list.AssignRandoms();

            list.Serialize();

            var deserializedList = new ListRandom();

            deserializedList.Deserialize();
        }
    }
}