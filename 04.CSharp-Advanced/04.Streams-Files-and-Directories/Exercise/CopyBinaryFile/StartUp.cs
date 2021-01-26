using System;
using System.IO;

namespace CopyBinaryFile
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (FileStream reader = new FileStream("../../../GosuMonkeyManiak.jpg", FileMode.Open, FileAccess.Read))
            {
                using (FileStream writer = new FileStream("../../../outPut.jpg", FileMode.Open, FileAccess.Write))
                {
                    long parts = (long)Math.Ceiling(reader.Length / 4.0);

                    byte[] buffer = new byte[parts];

                    reader.Read(buffer, 0, buffer.Length);
                    writer.Write(buffer, 0, buffer.Length);

                    while (reader.Position != reader.Length)
                    {
                        reader.Read(buffer, 0, buffer.Length);
                        writer.Write(buffer, 0, buffer.Length);
                    }

                }
            }
        }
    }
}
