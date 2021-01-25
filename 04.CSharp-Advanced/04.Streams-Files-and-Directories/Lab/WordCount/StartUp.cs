using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WordCount
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> times = new Dictionary<string, int>();

            using (FileStream fileInPut = new FileStream("../../../inPut.txt", FileMode.Open, FileAccess.Read))
            {
                using (FileStream fileWords = new FileStream("../../../words.txt", FileMode.Open, FileAccess.Read))
                {
                    using (FileStream fileWriter = new FileStream("../../../outPut.txt", FileMode.Open, FileAccess.Write))
                    {
                        byte[] buffer = new byte[2];

                        int line = fileWords.Read(buffer, 0, buffer.Length);

                        string word = Encoding.UTF8.GetString(buffer);

                        while (fileWords.Position != fileWords.Length)
                        {

                            line = fileWords.Read(buffer, 0, buffer.Length);
                            word += Encoding.UTF8.GetString(buffer);
                        }

                        string[] words = word.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                        buffer = new byte[fileInPut.Length / 2];

                        line = fileInPut.Read(buffer, 0, buffer.Length);

                        string text = Encoding.UTF8.GetString(buffer);

                        while (fileInPut.Position != fileInPut.Length)
                        {
                            line = fileInPut.Read(buffer, 0, buffer.Length);
                            text += Encoding.UTF8.GetString(buffer);
                        }


                        for (int i = 0; i < words.Length; i++)
                        {
                            int time = 0;

                            while (text.IndexOf(words[i]) != -1)
                            {
                                time++;
                                text = text.Remove(text.IndexOf(words[i]), words[i].Length);
                            }

                            times.Add(words[i], time);
                        }

                        byte dash = 45;

                        foreach (var item in times)
                        {
                            buffer = new byte[2];
                            buffer = Encoding.UTF8.GetBytes(item.Key);
                            fileWriter.Write(buffer, 0, buffer.Length);

                            fileWriter.Write(new byte[] { 45 }, 0, 1);

                            buffer = Encoding.UTF8.GetBytes(item.Value.ToString());
                            fileWriter.Write(buffer, 0, buffer.Length);

                            buffer = Encoding.UTF8.GetBytes("\n");
                            fileWriter.Write(buffer, 0, buffer.Length);
                        }


                    }
                }
            }
        }
    }
}
