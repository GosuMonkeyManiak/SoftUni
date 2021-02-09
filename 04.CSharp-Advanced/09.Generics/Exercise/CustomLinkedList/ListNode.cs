using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    class ListNode<T>
    {
        protected internal ListNode()
        {

        }
        protected internal ListNode(T value)
        {
            this.Value = value;
        }

        protected internal T Value { get; set; }

        protected internal ListNode<T> NextNode { get; set; }

        protected internal ListNode<T> PreviousNode { get; set; }
    }
}
