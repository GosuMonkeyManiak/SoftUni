namespace LetterCombinations
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            char notInclude = char.Parse(Console.ReadLine());

            int asciiCodeNotInclude = (int)notInclude;
            int count = 0;

            for (int i = (int) start; i <= (int) end; i++)
            {
                for (int j = (int)start; j <= (int)end; j++)
                {
                    for (int k = (int)start; k <= (int)end; k++)
                    {
                        if (i != asciiCodeNotInclude 
                            && j != asciiCodeNotInclude 
                            && k != asciiCodeNotInclude)
                        {
                            count++;
                            Console.Write($"{(char)i}{(char)j}{(char)k} ");
                        }
                    }
                }
            }

            Console.WriteLine($"{count}");
        }
    }
}
