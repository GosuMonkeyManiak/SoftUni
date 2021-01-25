using System;
using System.IO;

namespace OddLines
{
    class StartUp
    {
        static void Main(string[] args)
        {

            using (StreamReader streamReader = new StreamReader("../../../InPut.txt"))
            {
                using (StreamWriter streamWriter = new StreamWriter("../../../OutPut.txt"))
                {
                    string line = streamReader.ReadLine();
                    int count = 0;

                    while (line != null)
                    {
                        if (count % 2 != 0)
                        {
                            streamWriter.WriteLine(line);
                        }

                        count++;
                        line = streamReader.ReadLine();
                    }

                }
            }

            Console.WriteLine("Done");
        }
    }
}
