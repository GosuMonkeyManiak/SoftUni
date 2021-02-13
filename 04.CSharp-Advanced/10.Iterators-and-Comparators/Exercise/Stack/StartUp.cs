using System;
using System.Linq;

namespace Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            MyStack<int> stack = new MyStack<int>();

            while (true)
            {
                string fullcommand= Console.ReadLine();

                string command = string.Empty;
                string elements = string.Empty;

                if (fullcommand.Length > 4)
                {
                    command = fullcommand.Substring(0, fullcommand.IndexOf(' ')).Trim();
                    elements = fullcommand.Substring(fullcommand.IndexOf(' ') + 1);
                }
                

                if (fullcommand == "END")
                {
                    for (int i = 0; i < 2; i++)
                    {
                        foreach (var item in stack)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    break;
                }

                if (fullcommand == "Pop")
                {
                    stack.Pop();
                    continue;
                }

                int[] arr = elements
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int i = 0; i < arr.Length; i++)
                {
                    stack.Push(arr[i]);
                }

            }
            
        }
    }
}
