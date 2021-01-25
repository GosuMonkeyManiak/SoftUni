using System;
using System.IO;

namespace MergeFiles
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (FileStream fileReaderOne = new FileStream("../../../inPut1.txt", FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (FileStream fileReaderTwo = new FileStream("../../../inPut2.txt", FileMode.OpenOrCreate, FileAccess.Read))
                {
                    using (FileStream fileWriter = new FileStream("../../../outPut.txt", FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        byte[] buffer = new byte[3];

                        fileReaderOne.Read(buffer, 0, buffer.Length);
                        fileWriter.Write(buffer, 0, buffer.Length);

                        fileReaderTwo.Read(buffer, 0, buffer.Length);
                        fileWriter.Write(buffer, 0, buffer.Length);

                        while (fileReaderOne.Position != fileReaderOne.Length || fileReaderTwo.Position != fileReaderTwo.Length)
                        {
                            fileReaderOne.Read(buffer, 0, buffer.Length);
                            fileWriter.Write(buffer, 0, buffer.Length);

                            fileReaderTwo.Read(buffer, 0, buffer.Length);
                            fileWriter.Write(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
        }
    }
}
