using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace DoublyLinkedList
{
    internal class ListRandom
    {
        private ListNode _head;
        private ListNode _tail;
        private int Count { get; set; }

        public bool IsEmpty => Count == 0;

        public void Clear()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        public void AddLast(string data)
        {
            var node = new ListNode(data);

            if (_head == null)
            {
                _head = node;
            }
            else
            {
                _tail.Next = node;
                node.Previous = _tail;
            }

            _tail = node;
            Count++;
        }

        public void AddFirst(string data)
        {
            var node = new ListNode(data);
            var temp = _head;
            node.Next = temp;
            _head = node;
            if (Count == 0)
            {
                _tail = _head;
            }
            else
            {
                temp.Previous = node;
                Count++;
            }
        }

        public bool Remove(string data)
        {
            var current = _head;

            while (current != null)
            {
                if (current.Data == data)
                {
                    break;
                }

                current = current.Next;
            }

            if (current == null) return false;

            if (current.Next != null)
            {
                current.Next.Previous = current.Previous;
            }
            else
            {
                _tail = current.Previous;
            }


            if (current.Previous != null)
            {
                current.Previous.Next = current.Next;
            }
            else
            {
                _head = current.Next;
            }

            Count--;
            return true;
        }

        public bool Contains(string data)
        {
            var current = _head;
            while (current != null)
            {
                if (current.Data == data)
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public void Display()
        {
            var current = _head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }

        public void Serialize(Stream s)
        {
        }

        public void Deserialize(Stream s)
        {
        }
    }
}