using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunny_Glaases
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            while (n < 3 && n > 100)
            {
                Console.Write("n = ");
                n = int.Parse(Console.ReadLine());
            }

            Console.Write(new string('*', n * 2));
            Console.Write(new string(' ', n));
            Console.Write(new string('*', n * 2));

            Console.WriteLine();

            for (int mid = 0; mid < n - 2; mid++)
            {

                Console.Write("*");
                Console.Write(new string('/', (n * 2) - 2));
                Console.Write("*");

                if (true)
                {
                    Console.Write(new string('|', n));
                }
                else
                {
                    Console.Write(new string('|', n));
                }

                Console.Write("*");
                Console.Write(new string('/', (n * 2) - 2));
                Console.Write("*");

                Console.WriteLine();

            }

            Console.Write(new string('*', n * 2));
            Console.Write(new string(' ', n));
            Console.Write(new string('*', n * 2));

            Console.WriteLine();
        }

    }
}