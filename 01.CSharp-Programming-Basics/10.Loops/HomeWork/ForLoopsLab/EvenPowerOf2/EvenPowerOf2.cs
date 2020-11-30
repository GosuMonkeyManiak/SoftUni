using System;

namespace EvenPowerOf2
{
    class EvenPowerOf2
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i <= num; i += 2)
            {
                Console.WriteLine(Math.Pow(2,i));
            }
        }
    }
}
