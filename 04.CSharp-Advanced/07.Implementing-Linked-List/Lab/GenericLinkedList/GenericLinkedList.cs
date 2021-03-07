using System;
using System.Collections.Generic;
using System.Text;

namespace GenericLinkedList
{
    public class GenericLinkedList<T>
    {
        public GenericLinkedList()
        {

        }

        public Node<T> Head { get; set; }

        public Node<T> Tail { get; set; }

        public void AddFirst(T element)
        {
            Node<T> elementToAdd = new Node<T>(element);

            if (this.Head == null && this.Tail == null)
            {
                this.Head = elementToAdd;
                this.Tail = elementToAdd;
                return;
            }

            this.Head.Previous = elementToAdd;
            elementToAdd.Next = this.Head;
            this.Head = elementToAdd;
        }

        public void AddLast(T element)
        {
            Node<T> elementToAdd = new Node<T>(element);

            if (this.Head == null && this.Tail == null)
            {
                this.Head = elementToAdd;
                this.Tail = elementToAdd;
                return;
            }

            elementToAdd.Previous = this.Tail;
            this.Tail.Next = elementToAdd;
            this.Tail = elementToAdd;
        }

        public T RemoveFirst()
        {
            if (this.Head == null && this.Tail == null)
            {
                throw new NullReferenceException();
            }

            Node<T> element = this.Head;

            if (element.Next == null) //only one element
            {
                this.Head = this.Tail = null;
            }
            else // != null
            {
                this.Head = this.Head.Next;
                this.Head.Previous = null;
            }

            return element.Value;
        }

        public T RemoveLast()
        {
            if (this.Head == null && this.Tail == null)
            {
                throw new NullReferenceException();
            }

            Node<T> element = this.Tail;

            if (element.Previous == null) //only one
            {
                this.Tail = this.Head = null;
            }
            else // != null
            {
                this.Tail = this.Tail.Previous;
                this.Tail.Next = null;
            }

            return element.Value;
        }

        public void ForEach(Action<T> action)
        {
            Node<T> cuurentNode = this.Head;

            while (cuurentNode != null)
            {
                action(cuurentNode.Value);
                cuurentNode = cuurentNode.Next;
            }
        }
    }
}
