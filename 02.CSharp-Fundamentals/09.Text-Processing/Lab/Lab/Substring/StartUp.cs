using System;

namespace Substring
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string first = Console.ReadLine().ToLower();
            string second = Console.ReadLine().ToLower();

            string result = string.Empty;

            while (second.IndexOf(first) != -1)
            {
                int index = second.IndexOf(first);

                result += second.Substring(0, index);
                result += second.Substring(index + first.Length);

                second = result;
                result = string.Empty;
            }

            Console.WriteLine(second);
        }
    }
}
