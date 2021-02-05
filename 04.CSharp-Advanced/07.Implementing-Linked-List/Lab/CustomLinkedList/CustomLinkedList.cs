using System;
using System.Collections.Generic;

namespace CustomLinkedList
{
    public class CustomLinkedList
    {
        public Node Head { get; set; }

        public Node Tail { get; set; }

        public void AddFirst(int element)
        {
            Node newNode = new Node(element);

            if (this.Head == null && this.Tail == null)
            {
                this.Head = newNode;
                this.Tail = newNode;
                return;
            }

            this.Head.Previous = newNode;
            newNode.Next = this.Head;
            this.Head = newNode;
        }

        public void AddLast(int element)
        {
            Node newNode = new Node(element);

            if (this.Head == null && this.Tail == null)
            {
                this.Head = newNode;
                this.Tail = newNode;
                return;
            }

            this.Tail.Next = newNode;
            newNode.Previous = this.Tail;
            this.Tail = newNode;
        }

        public int RemoveFirst()
        {
            if (this.Head == null && this.Tail == null)
            {
                throw new NullReferenceException();
            }

            int element = this.Head.Value;
            this.Head = this.Head.Next;
            if (this.Head != null)
            {
                this.Head.Previous = null;
            }
            else //null
            {
                this.Tail = null;
            }

            return element;
        }

        public int RemoveLast()
        {
            if (this.Head == null && this.Tail == null)
            {
                throw new NullReferenceException();
            }

            int element = this.Tail.Value;
            this.Tail = this.Tail.Previous;

            if (this.Tail != null)
            {
                this.Tail.Next = null;
            }
            else //null
            {
                this.Head = null;
            }

            return element;
        }

        public void ForEach(Action<int> action)
        {
            Node currentNode = this.Head;

            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }

        public int[] ToArray()
        {
            List<int> array = new List<int>();

            ForEach(x => array.Add(x));

            return array.ToArray();
        }
    }
}
