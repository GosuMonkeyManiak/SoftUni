using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        private class Node
        {
            public Node(T element)
            {
                Value = element;
            }

            public T Value { get; set; }

            public Node Next { get; set; }

            public Node Previous { get; set; }
        }

        private Node head;
        private Node tail;

        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new Node(element);
            }
            else
            {
                Node newHead = new Node(element);
                newHead.Next = this.head;
                this.head.Previous = newHead;
                this.head = newHead;
            }

            Count++;
        }

        public void AddLast(T element)
        {
            if (this.Count == 0)
            {
                this.tail = this.head = new Node(element);
            }
            else
            {
                Node newTail = new Node(element);
                newTail.Previous = this.tail;
                this.tail.Next = newTail;
                this.tail = newTail;
            }

            Count++;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            T firstElement = this.head.Value;

            this.head = this.head.Next;
            if (head != null)
            {
                this.head.Previous = null;
            }
            else
            {
                this.tail = null;
            }

            Count--;
            return firstElement;
        }

        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            T lastElement = tail.Value;

            tail = tail.Previous;
            if (tail != null)
            {
                tail.Next = null;
            }
            else
            {
                head = null;
            }

            Count--;
            return lastElement;
        }

        public void ForEach(Action<T> action)
        {
            Node current = this.head;

            while (current != null)
            {
                action(current.Value);
                current = current.Next;
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];
            int index = 0;

            Node current = this.head;

            while (current != null)
            {
                array[index] = current.Value;
                current = current.Next;
                index++;
            }

            return array;
        }
    }
}
