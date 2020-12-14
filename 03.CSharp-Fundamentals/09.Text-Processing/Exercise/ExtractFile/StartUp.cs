using System;

namespace ExtractFile
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string filePath = Console.ReadLine();

            int indexOfLastBackSlash = filePath.LastIndexOf('\\');

            string file = filePath.Substring(indexOfLastBackSlash + 1);

            int indexFileType = file.LastIndexOf('.');

            string resultFile = file.Substring(0, indexFileType);
            string resultFileType = file.Substring(indexFileType + 1);


            Console.WriteLine($"File name: {resultFile}");
            Console.WriteLine($"File extension: {resultFileType}");
        }
    }
}
