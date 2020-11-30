using System;

namespace GreaterOfTwoValues
{
    class GreaterOfTwoValues
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            switch (type)
            {
                case "int":
                    int firstNumber = int.Parse(Console.ReadLine());
                    int secondNumber = int.Parse(Console.ReadLine());

                    int intResult = GetMax(firstNumber, secondNumber);

                    Console.WriteLine(intResult);
                    break;

                case "char":
                    char first = char.Parse(Console.ReadLine());
                    char second = char.Parse(Console.ReadLine());

                    char CharResult = GetMax(first, second);

                    Console.WriteLine(CharResult);
                    break;

                case "string":
                    string someStringOne = Console.ReadLine();
                    string someStringTwo = Console.ReadLine();

                    string stringResult = GetMax(someStringOne, someStringTwo);

                    Console.WriteLine(stringResult);
                    break;
                default:
                    break;
            }
        }

        public static int GetMax(int firstNum, int secondNum)
        {
            if (firstNum > secondNum)
            {
                return firstNum;
            }
            else
            {
                return secondNum;
            }
        }

        public static char GetMax(char first, char second)
        {
            if (first > second)
            {
                return first;
            }
            else
            {
                return second;
            }
        }

        public static string GetMax(string first, string second)
        {
            if (first.Equals(second) == true)
            {
                return first;
            }
            else
            {
                return second;
            }
        }
    }
}
