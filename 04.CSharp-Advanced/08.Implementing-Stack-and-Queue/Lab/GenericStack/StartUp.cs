using System;
using System.Collections.Generic;

namespace GenericStack
{
    class StartUp
    {
        static void Main(string[] args)
        {
            CustomStack<int> stack = new CustomStack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            stack.Pop();
            stack.Pop();

            Console.WriteLine(stack.Peek());


            stack.Foreach(x => Console.WriteLine(x));
        }
    }
}
