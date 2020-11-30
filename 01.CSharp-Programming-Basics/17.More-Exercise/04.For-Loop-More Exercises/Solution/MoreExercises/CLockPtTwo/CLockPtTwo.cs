using System;

namespace CLockPtTwo
{
    class CLockPtTwo
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    for (int n = 0; n < 60; n++)
                    {
                        Console.Write($"{i} : {j} : {n}");
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
