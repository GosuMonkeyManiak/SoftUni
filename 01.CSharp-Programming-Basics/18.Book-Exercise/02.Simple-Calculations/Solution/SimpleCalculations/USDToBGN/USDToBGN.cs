using System;

namespace USDToBGN
{
    class USDToBGN
    {
        static void Main(string[] args)
        {
            double usb = double.Parse(Console.ReadLine());

            double bgn = usb * 1.79549;

            Console.WriteLine(Math.Round(bgn, 2) + " BGN");
        }
    }
}
