using System;

namespace DecrypingMessages
{
    class DecrypingMessages
    {
        static void Main(string[] args)
        {
            byte key = byte.Parse(Console.ReadLine());
            byte n = byte.Parse(Console.ReadLine());

            string result = null;

            for (int i = 0; i < n; i++)
            {
                char letter = char.Parse(Console.ReadLine());

                letter = (char)(letter + key);
                result += letter.ToString();
            }

            Console.WriteLine(result);
        }
    }
}
