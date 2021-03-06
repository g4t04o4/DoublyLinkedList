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
    struct NodeCitation //некрасиво и ненужно, переделать
    {
        public ListNode _node { get; set; }
        public int _key { get; set; }
        public int _next { get; set; }
        public int _previous { get; set; }
        public int _random { get; set; }

        public string _data { get; set; }
    }

    internal class ListRandom
    {
        public ListNode Head;
        public ListNode Tail;
        public int Count;

        public bool IsEmpty => Count == 0;

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public void AddLast(string data)
        {
            var node = new ListNode(data);

            if (Head == null)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
            }

            Tail = node;
            Count++;
        }

        public void AddFirst(string data)
        {
            var node = new ListNode(data);
            var temp = Head;
            node.Next = temp;
            Head = node;
            if (Count == 0)
            {
                Tail = Head;
            }
            else
            {
                temp.Previous = node;
                Count++;
            }
        }

        public bool Remove(string data)
        {
            var current = Head;

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
                Tail = current.Previous;
            }


            if (current.Previous != null)
            {
                current.Previous.Next = current.Next;
            }
            else
            {
                Head = current.Next;
            }

            Count--;
            return true;
        }

        public bool Contains(string data)
        {
            var current = Head;
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

        public void AssignRandoms()
        {
            var current = Head;
            while (current != null)
            {
                current.Random = Head.Next;

                current = current.Next;
            }
        }

        public void Display()
        {
            var current = Head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }

        public string EncodeListContent()
        {
            var counter = 0;
            var content = "";
            var current = Head;
            var citation = new NodeCitation[Count];

            while (current != null)
            {
                current.Key = counter;
                citation[counter]._node = current;
                citation[counter]._key = counter;
                counter++;
                current = current.Next;
            }

            counter = 0;
            current = Head;

            while (current != null)
            {
                if (current.Next != null)
                    citation[counter]._next = current.Next.Key;
                else
                    citation[counter]._next = -1;

                if (current.Previous != null)
                    citation[counter]._previous = current.Previous.Key;
                else
                    citation[counter]._previous = -1;

                citation[counter]._random = current.Random.Key;

                content += citation[counter]._key + "|" +
                           citation[counter]._next + "|" +
                           citation[counter]._previous + "|" +
                           citation[counter]._random + "|" +
                           citation[counter]._node.Data + "\n";

                counter++;
                current = current.Next;
            }

            return content;
        } //отвратительная реализация, нужно переделать потом

        public void Serialize() //временно убрал аргумент Stream s
        {
            var path = @"savefile.txt";
            using (StreamWriter streamWriter = File.AppendText(path))
            {
                streamWriter.WriteLine(EncodeListContent());
                streamWriter.Close();
            }
        }

        public void FillFromString(string content)
        {
            this.Clear();

            var lines = content.Split('\n');

            var citation = new NodeCitation[lines.Count()];

            foreach (var line in lines)
            {
                var split = line.Split('|');
                var key = int.Parse(split[0]);
                citation[key]._key = key;
                citation[key]._next = int.Parse(split[1]);
                citation[key]._previous = int.Parse(split[2]);
                citation[key]._random = int.Parse(split[3]);
                citation[key]._data = split[4];
            }
        }

        public void Deserialize() //временно убрал аргумент Stream s
        {
            var path = @"savefile.txt";
            string content = "", temp;
            using (StreamReader streamReader = File.OpenText(path))
            {
                while ((temp = streamReader.ReadLine()) != null)
                {
                    content += temp;
                }
            }

            FillFromString(content);
        }
    }
}