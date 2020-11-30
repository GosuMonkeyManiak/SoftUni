using System;

namespace AddAndSubtract
{
    class AddAndSubtract
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int result = Subtract(Add(firstNumber, secondNumber), thirdNumber);

            Console.WriteLine(result);
        }

        static int Add(int firstNum, int secondNum)
        {
            return firstNum + secondNum;
        }

        static int Subtract(int result, int thirdnum)
        {
            return result - thirdnum;
        }
    }
}
