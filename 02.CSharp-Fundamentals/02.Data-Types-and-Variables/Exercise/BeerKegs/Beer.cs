using System;

namespace BeerKegs
{
    class Beer
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());

            double bigges = 0;
            string biggesModel = null;

            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                float radius = float.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = Math.PI * Math.Pow(radius, 2) * height;

                if (volume > bigges)
                {
                    bigges = volume;
                    biggesModel = model;
                }
            }

            Console.WriteLine(biggesModel);
        }
    }
}
