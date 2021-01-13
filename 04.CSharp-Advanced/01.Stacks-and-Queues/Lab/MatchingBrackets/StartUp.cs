using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            Stack<int> bracketsIndex = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    bracketsIndex.Push(i);
                }

                if (expression[i] == ')')
                {
                    int startIndex = bracketsIndex.Pop();

                    string subExpression = expression.Substring(startIndex, i - startIndex + 1);

                    Console.WriteLine(subExpression);
                }
            }
        }
    }
}
