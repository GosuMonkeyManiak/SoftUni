using System;

namespace Diamonds
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int stars = 1;
            if (n % 2 == 0)
            {
                stars++;
            }

            int leftRigth = (int)Math.Floor((n - 1) / 2f);

            int len = 0;

            if (n % 2 == 0)
            {
                len = n / 2;
            }
            else
            {
                len = (int)Math.Floor(n / 2f + 1);
            }
            

            for (int i = 0; i < len; i++) //upper
            {
                if (i == 0)
                {
                    Console.Write(new string('-', leftRigth));
                    Console.Write(new string('*', stars));
                    Console.Write(new string('-', leftRigth));
                    Console.WriteLine();
                    leftRigth--;
                }
                else
                {
                    int mid = n - 2 * leftRigth - 2;
                    Console.Write(new string('-', leftRigth));
                    Console.Write("*");
                    Console.Write(new string('-', mid));
                    Console.Write("*");
                    Console.Write(new string('-', leftRigth));
                    Console.WriteLine();
                    leftRigth--;
                }
            }

            leftRigth += 2;
            len = (int)Math.Floor((n - 1) / 2f);

            for (int i = 0; i < len; i++)
            {
                if (i == len - 1)
                {
                    Console.Write(new string('-',leftRigth));
                    Console.Write(new string('*',stars));
                    Console.Write(new string('-',leftRigth));
                }
                else
                {
                    int mid = n - 2 * leftRigth - 2;
                    Console.Write(new string('-',leftRigth));
                    Console.Write("*");
                    Console.Write(new string('-',mid));
                    Console.Write("*");
                    Console.Write(new string('-',leftRigth));
                    Console.WriteLine();
                    leftRigth++;
                }
            }
        }
    }
}
