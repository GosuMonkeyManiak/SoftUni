using System;

namespace TriFunction
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> condition = IfSumOfWordsIsGreater;

            for (int i = 0; i < names.Length; i++)
            {
                if (condition(names[i], n))
                {
                    Console.WriteLine(names[i]);
                    return;
                }
            }
            
        }

        static bool IfSumOfWordsIsGreater(string name, int max)
        {
            int sum = 0;

            for (int i = 0; i < name.Length; i++)
            {
                sum += name[i];
            }

            if (sum >= max)
            {
                return true;
            }


            return false;
        }
    }
}
