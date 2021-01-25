using System;
using System.IO;
using System.Linq;

namespace EvenLines
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int count = 0;
            using(StreamReader streamReader = new StreamReader("../../../text.txt"))
            {
                string line = streamReader.ReadLine();

                while (line != null)
                {
                    if (count % 2 == 0) 
                    {
                        char[] special = new char[] { '-', ',', '.', '!', '?'};
                        for (int i = 0; i < special.Length; i++)
                        {
                            line = line.Replace(special[i], '@');
                        }

                        string[] toPrint = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                         
                        string result = "";

                        for (int i = toPrint.Length - 1; i >= 0; i--)
                        {
                            result += toPrint[i] + " ";
                        }

                        
                        Console.WriteLine(result);
                    }

                    line = streamReader.ReadLine();
                    count++;
                }
            }
        }
    }
}
