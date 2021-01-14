using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTextEditor
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int operations = int.Parse(Console.ReadLine());

            StringBuilder builder = new StringBuilder();
            Stack<string> stack = new Stack<string>();

            stack.Push(builder.ToString());

            for (int i = 0; i < operations; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];

                switch(command)
                {
                    case "1":
                        builder.Append(tokens[1]);
                        stack.Push(builder.ToString());
                        break;

                    case "2":
                        builder.Remove(builder.Length - int.Parse(tokens[1]), int.Parse(tokens[1]));
                        stack.Push(builder.ToString());
                        break;

                    case "3":
                        int index = int.Parse(tokens[1]);
                        Console.WriteLine(builder[index - 1]);
                        break;

                    case "4":
                        stack.Pop();
                        builder = new StringBuilder();
                        builder.Append(stack.Peek());
                        break;

                    default:
                        break;
                }

            }

        }
    }
}
