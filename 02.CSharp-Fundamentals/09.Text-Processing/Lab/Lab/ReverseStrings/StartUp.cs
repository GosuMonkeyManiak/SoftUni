using System;
using System.Linq;

namespace ReverseStrings
{
    class StartUp
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string inPut = Console.ReadLine();
                if (inPut == "end")
                {
                    break;
                }

                string reverse = string.Empty;

                for (int i = inPut.Length - 1; i >= 0; i--)
                {
                    reverse += inPut[i];
                }


                Console.WriteLine($"{inPut} = {reverse}");
            }
        }
    }
}
