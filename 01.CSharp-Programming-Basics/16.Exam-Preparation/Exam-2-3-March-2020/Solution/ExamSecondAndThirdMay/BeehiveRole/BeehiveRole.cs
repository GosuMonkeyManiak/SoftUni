using System;

namespace BeehiveRole
{
    class BeehiveRole
    {
        static void Main(string[] args)
        {
            int intelekt = int.Parse(Console.ReadLine());
            int strength = int.Parse(Console.ReadLine());
            string mOrf = Console.ReadLine();

            if (intelekt >= 80)
            {
                if (strength >= 80 && mOrf == "female")
                {
                    Console.WriteLine("Queen Bee");
                }
                else
                {
                    Console.WriteLine("Repairing Bee");
                }
            }
            else if (intelekt >= 60)
            {
                Console.WriteLine("Cleaning Bee");
            }
            else
            {
                if (strength >= 80 && mOrf == "male")
                {

                    Console.WriteLine("Drone Bee");
                }
                else if (strength >= 60)
                {
                    Console.WriteLine("Guard Bee");
                }
                else
                {
                    Console.WriteLine("Worker Bee");
                }
            }
        }
    }
}
