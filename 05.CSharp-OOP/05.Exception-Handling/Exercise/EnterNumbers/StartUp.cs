using System;
using System.Threading;

namespace EnterNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {

            loop:

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    ReadNumber(1, 100);
                }
                catch (FormatException)
                {
                    goto loop;
                }
                catch (OverflowException)
                {
                    goto loop;
                }
                catch (ArithmeticException)
                {
                    goto loop;
                }

            }


        }

        static void ReadNumber(int start, int end)
        {

            int number = int.Parse(Console.ReadLine());

            if (number < start || number > end)
            {
                throw new ArithmeticException();
            }
        }
    }
}
