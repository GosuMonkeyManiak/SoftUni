using System;

namespace MathOperations
{
    class MathOperations
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            char operators = char.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());

            double result = Calculate(firstNumber, operators, secondNumber);

            Console.WriteLine(result);

        }

        public static double Calculate(double firstNum, char operators, double secondNum)
        {
            double result = 0;

            switch (operators)
            {
                case '+':
                    result = firstNum + secondNum;
                    break;

                case '-':
                    result = firstNum - secondNum;
                    break;

                case '*':
                    result = firstNum * secondNum;
                    break;

                case '/':
                    result = firstNum / secondNum;
                    break;
            }

            return result;
        }
    }
}
