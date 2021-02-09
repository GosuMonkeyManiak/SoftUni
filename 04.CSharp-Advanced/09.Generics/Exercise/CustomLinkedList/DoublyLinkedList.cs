using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    class DoublyLinkedList<T> : ListNode<T>
    {
        public DoublyLinkedList() : base()
        {

        }

        public int Count { get; private set; }

        public ListNode<T> Head { get; set; }

        public ListNode<T> tail { get; set; }

        public void AddFirst(T element)
        {
            if (Count == 0)
            {
                this.Head = this.tail = new ListNode<T>(element);
            }
            else
            {
                var newHead = new ListNode<T>(element);
                newHead.NextNode = this.Head;
                this.Head.PreviousNode = newHead;
                this.Head = newHead;
            }

            this.Count++;
        }

        public void AddLast(T element)
        {
            if (this.Count == 0)
            {
                this.Head = this.tail = new ListNode<T>(element);
            }
            else
            {
                var newTail = new ListNode<T>(element);
                newTail.PreviousNode = this.tail;
                this.tail.NextNode = newTail;
                this.tail = newTail;
            }

            this.Count++;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new IndexOutOfRangeException("The list is empty");
            }

            var firstElement = this.Head.Value;
            this.Head = this.Head.NextNode;
            if (this.Head != null)
            {
                this.Head.PreviousNode = null;
            }
            else
            {
                this.tail = null;
            }

            this.Count--;
            return firstElement;
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new IndexOutOfRangeException("The list is empty");
            }

            var lastElement = this.tail.Value;
            this.tail = this.tail.PreviousNode;
            if (this.tail != null)
            {
                this.tail.NextNode = null;
            }
            else
            {
                this.Head = null;
            }

            this.Count--;
            return lastElement;
        }

        public void ForEach(Action<T> action)
        {
            ListNode<T> cuurentNode = this.Head;

            while (cuurentNode != null)
            {
                action(cuurentNode.Value);
                cuurentNode = cuurentNode.NextNode;
            }
        }

        public T[] ToArray()
        {
            T[] arr = new T[Count];

            ListNode<T> current = Head;

            int index = 0;

            while (current != null)
            {
                arr[0] = current.Value;
                current = current.NextNode;
                index++;
            }

            return arr;
        }
    }
}
