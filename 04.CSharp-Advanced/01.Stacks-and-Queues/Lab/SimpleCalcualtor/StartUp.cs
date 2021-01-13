using System;
using System.Collections.Generic;

namespace SimpleCalcualtor
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] inPut = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Stack<string> expression = new Stack<string>();

            for (int i = inPut.Length - 1; i >= 0; i--)
            {
                expression.Push(inPut[i]);
            }

            while (expression.Count > 1)
            {
                int firstNumber = int.Parse(expression.Pop());
                string sign = expression.Pop();
                int secondNumber = int.Parse(expression.Pop());

                if (sign == "+")
                {
                    expression.Push((firstNumber + secondNumber).ToString());
                }
                else if (sign == "-")
                {
                    expression.Push((firstNumber - secondNumber).ToString());
                }
                
            }

            Console.WriteLine(expression.Pop());
        }
    }
}
