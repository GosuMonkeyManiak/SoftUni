using System;

namespace ReadText
{
    class ReadText
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            while (name != "Stop")
            {
                name = Console.ReadLine();
            }
        }
    }
}
