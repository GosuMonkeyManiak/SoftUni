using System;
using System.IO;
using System.Text;

namespace FolderSize
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles("../../../");

            double sum = 0;

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                sum += fileInfo.Length;
            }

            sum = sum / 1024 / 1024;

            using (FileStream fileStream = new FileStream("../../../out.txt", FileMode.OpenOrCreate, FileAccess.Write))
            {
                byte[] buffer = Encoding.UTF8.GetBytes(sum.ToString());
                fileStream.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
