using System;
using System.Collections.Generic;

namespace DoublyLinkedList
{
    internal class ListNode
    {
        public ListNode Previous;
        public ListNode Next;
        public ListNode Random;
        public string Data;
        public int Key; // излишние данные для ноды, убрать

        public ListNode(string data)
        {
            Data = data;
        }
    }
}