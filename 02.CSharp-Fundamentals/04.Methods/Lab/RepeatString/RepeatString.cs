using System;
using System.Text;

namespace RepeatString
{
    class RepeatString
    {
        static void Main(string[] args)
        {
            string sample = Console.ReadLine();
            int repeatTime = int.Parse(Console.ReadLine());

            Console.WriteLine(RepeatNTimeString(sample, repeatTime));
        }

        public static string RepeatNTimeString(string sample, int repeatTime)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < repeatTime; i++)
            {
                result.Append(sample);
            }

            return result.ToString();
        }
    }
}
