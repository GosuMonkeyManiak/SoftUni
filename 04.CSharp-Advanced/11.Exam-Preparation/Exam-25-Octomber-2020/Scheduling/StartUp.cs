using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //first give thread
            //last task

            Stack<int> tasks = new Stack<int>(Console.ReadLine()
                .Split(", ")
                .Select(int.Parse));

            Queue<int> thread = new Queue<int>(Console.ReadLine()
                .Split(" ")
                .Select(int.Parse));

            int taskToBeKilled = int.Parse(Console.ReadLine());

            while (true)
            {
                int currentThread = thread.Peek();
                int currentTask = tasks.Peek();

                if (currentTask == taskToBeKilled)
                {
                    Console.WriteLine($"Thread with value {currentThread} killed task {currentTask}");
                    Console.WriteLine(string.Join(" ", thread));
                    break;
                }
                else if (currentThread >= currentTask)
                {
                    tasks.Pop();
                    thread.Dequeue();
                }
                else if (currentThread < currentTask)
                {
                    thread.Dequeue();
                }
            }

        }
    }
}
