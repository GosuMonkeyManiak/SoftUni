using System;

namespace PipesInPool
{
    class PipesInPool
    {
        static void Main(string[] args)
        {
            int volumePoolLiters = int.Parse(Console.ReadLine());
            int firstPipeDebitPerHour = int.Parse(Console.ReadLine());
            int secondPipeDebitPerHour = int.Parse(Console.ReadLine());
            double workerOut = double.Parse(Console.ReadLine());

            double firstPipeFill = firstPipeDebitPerHour * workerOut;
            double secondPipeFill = secondPipeDebitPerHour * workerOut;

            double allFillLiters = (firstPipeDebitPerHour * workerOut) + (secondPipeDebitPerHour * workerOut);

            if (allFillLiters > volumePoolLiters)
            {
                Console.WriteLine($"For {workerOut} hours the pool overflows with {allFillLiters - volumePoolLiters} liters.");
            }
            else
            {
                Console.WriteLine($"The pool is {Math.Truncate(allFillLiters / volumePoolLiters * 100)}% full. Pipe 1: {Math.Truncate(firstPipeFill / allFillLiters * 100)}%. Pipe 2: {Math.Truncate(secondPipeFill / allFillLiters * 100)}%.");
            }
        }
    }
}
