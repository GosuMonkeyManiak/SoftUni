using System;

namespace Calculations
{
    class Calculations
    {
        static void Main(string[] args)
        {
            string mathAction = Console.ReadLine();
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            switch (mathAction)
            {
                case "multiply":
                    Multiply(firstNumber, secondNumber);
                    break;

                case "subtract":
                    Subtract(firstNumber, secondNumber);
                    break;

                case "divide":
                    Divide(firstNumber, secondNumber);
                    break;

                case "add":
                    Add(firstNumber, secondNumber);
                    break;
                default:
                    break;
            }
        }

        public static void Multiply(int firstNum, int secondNum)
        {
            Console.WriteLine(firstNum * secondNum);
        }

        public static void Subtract(int firstNum, int secondNum)
        {
            Console.WriteLine(Math.Abs(firstNum - secondNum));
        }

        public static void Divide(int firstNum, int secondNum)
        {
            Console.WriteLine((double)(firstNum / secondNum));
        }

        public static void Add(int firstNum, int secondNum)
        {
            Console.WriteLine(firstNum + secondNum);
        }
    }
}
