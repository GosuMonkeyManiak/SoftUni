using System;

namespace AsciiSumator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            char firstCharacter = char.Parse(Console.ReadLine());
            char secondCharacter = char.Parse(Console.ReadLine());

            string text = Console.ReadLine();

            int sum = 0;

            int start = Math.Min(firstCharacter, secondCharacter);
            int end = Math.Max(firstCharacter, secondCharacter);

            for (int i = 0; i < text.Length; i++)
            {
                char character = text[i];

                if (character > start && character < end)
                {
                    sum += (int)character;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
