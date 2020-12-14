using System;
using System.Linq;

namespace CommonElements
{
    class CommonElements
    {
        static void Main(string[] args)
        {
            string[] firstArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] secondArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            string result = string.Empty;

            for (int i = 0; i < secondArr.Length; i++)
            {
                for (int j = 0; j < firstArr.Length; j++)
                {
                    if (secondArr[i] == firstArr[j])
                    {
                        result += secondArr[i];
                        result += " ";
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}
