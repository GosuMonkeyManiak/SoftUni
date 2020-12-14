using System;

namespace RepeatStrings
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string result = string.Empty;

            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < words[i].Length; j++)
                {
                    result += words[i];
                }
            }

            Console.WriteLine(result);
        }
    }
}
