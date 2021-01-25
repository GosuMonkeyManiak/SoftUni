using System;
using System.Collections.Generic;
using System.IO;

namespace SliceAFile
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> slice = new List<string>() { "Part-1.txt", "Part-2.txt", "Part-3.txt", "Part-4.txt" };

            int parts = 4;

            using (FileStream reader = new FileStream("../../../inPut.txt", FileMode.OpenOrCreate, FileAccess.Read))
            {
                long currentLenght = (long)(Math.Ceiling(reader.Length / (double)parts));

                for (int i = 0; i < parts; i++)
                {
                    using (FileStream writer = new FileStream($"../../../{slice[i]}", FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        byte[] buffer = new byte[currentLenght];
                        reader.Read(buffer, 0, buffer.Length);
                        writer.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
