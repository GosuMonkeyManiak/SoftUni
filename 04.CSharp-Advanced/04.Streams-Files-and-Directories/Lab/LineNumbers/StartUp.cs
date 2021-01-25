using System;
using System.IO;

namespace LineNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (StreamReader streamReader = new StreamReader("../../../inPut.txt"))
            {
                using (StreamWriter streamWriter = new StreamWriter("../../../outPut.txt"))
                {
                    string line = streamReader.ReadLine();
                    int count = 1;

                    while (line != null)
                    {
                        streamWriter.WriteLine($"{count}. {line}");

                        line = streamReader.ReadLine();
                        count++;
                    }

                }

            }

            Console.WriteLine("Done");
        }
    }
}
