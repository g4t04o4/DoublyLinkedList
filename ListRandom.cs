using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace DoublyLinkedList
{
    internal class ListRandom
    {
        public ListNode Head;
        public ListNode Tail;
        public int Count;

        public void Serialize(Stream s)
        {
        }

        public void Deserialize(Stream s)
        {
        }
    }
}