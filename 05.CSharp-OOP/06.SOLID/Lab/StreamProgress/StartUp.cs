using System;
using System.Threading;
using StreamProgress.Models;

namespace StreamProgress
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Movie file = new Movie(200, 10, "Gosho");

            StreamProgressInfo stream = new StreamProgressInfo(file);

            while (true)
            {
                int sent = stream.CalculateCurrentPercent();

                if (sent < 0)
                {
                    break;
                }

                Console.WriteLine($"{sent}% sent");
                Thread.Sleep(200);
            }
        }
    }
}
