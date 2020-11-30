using System;

namespace Elevator
{
    class elevator
    {
        static void Main(string[] args)
        {
            ushort person = ushort.Parse(Console.ReadLine());
            ushort capacity = ushort.Parse(Console.ReadLine());

            int result = (int)(Math.Ceiling((double)person / capacity));

            Console.WriteLine(result);
        }
    }
}
