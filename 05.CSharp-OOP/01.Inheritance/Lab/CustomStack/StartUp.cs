using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();

            Stack<string> stack1 = stack.AddRange(new string[] { "1", "2", "3", "4" });

            Console.WriteLine(string.Join(" ", stack1));
        }
    }
}
