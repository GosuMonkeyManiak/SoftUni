﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T> : IEnumerable<T>
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
        private class ListIterator : IEnumerator<T>
        {
            private List<T> items;
            private int index;

            public ListIterator(IEnumerable<T> items)
            {
                Reset();
                this.items = new List<T>(items);
            }

            public T Current => items[index];

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                items = null;
            }

            public bool MoveNext() => ++index < items.Count;

            public void Reset()
            {
                index = -1;
            }
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

        public IEnumerator<T> GetEnumerator()
        {
            return new ListIterator(ToArray());
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
