using System;

namespace PipesInPool
{
    class PipesInPool
    {
        static void Main(string[] args)
        {
            int volume = int.Parse(Console.ReadLine());
            int pOne = int.Parse(Console.ReadLine()); //For hour
            int pTwo = int.Parse(Console.ReadLine()); //For hour
            double hours = double.Parse(Console.ReadLine());

            double pOneFill = pOne * hours;
            double pTwoFill = pTwo * hours;

            double allFillVolume = pOneFill + pTwoFill;

            if (allFillVolume <= volume)
            {
                Console.WriteLine($"The pool os {(allFillVolume/volume) * 100:f2}% full. Pipe 1: {(pOneFill/allFillVolume) * 100:f2}%. Pipe 2: {(pTwoFill/allFillVolume) * 100:f2}%.");
            }
            else
            {
                Console.WriteLine($"For {hours} hours the pool overflows with {allFillVolume - volume:f2} liters.");
            }
        }
    }
}
