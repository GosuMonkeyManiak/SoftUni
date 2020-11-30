using System;

namespace FromUSBToBGN
{
    class FromUSBToBGN
    {
        static void Main(string[] args)
        {
            double usb = double.Parse(Console.ReadLine());

            double bgn = usb * 1.79549;

            Console.WriteLine($"{bgn:f2}");
        }
    }
}
