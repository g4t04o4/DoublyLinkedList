using System;
using System.Collections.Generic;

namespace DoublyLinkedList
{
    internal class ListNode
    {
        public ListNode Previous;
        public ListNode Next;
        public ListNode Random;
        public readonly string Data;

        public ListNode(string data)
        {
            Data = data;
        }
    }
}