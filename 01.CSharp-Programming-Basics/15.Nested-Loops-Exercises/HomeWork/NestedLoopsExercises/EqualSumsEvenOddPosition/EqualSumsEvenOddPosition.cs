using System;

namespace EqualSumsEvenOddPosition
{
    class EqualSumsEvenOddPosition
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            string textNum = "";
            int EvenSum = 0;
            int OddSum = 0;

            for (int i = num1; i <= num2; i++)
            {
                for (int k = 0; k < 6; k++)
                {
                    textNum = i.ToString();

                    if (k % 2 == 0)
                    {
                        EvenSum += textNum[k];
                    }
                    else
                    {
                        OddSum += textNum[k];
                    }
                }

                if (EvenSum == OddSum)
                {
                    Console.Write(i + " ");
                    EvenSum = 0;
                    OddSum = 0;
                }
                else
                {
                    EvenSum = 0;
                    OddSum = 0;
                }
            }
        }
    }
}
