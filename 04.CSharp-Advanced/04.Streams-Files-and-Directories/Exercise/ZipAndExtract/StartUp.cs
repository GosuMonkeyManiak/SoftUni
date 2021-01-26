using System;
using System.IO.Compression;

namespace ZipAndExtract
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (ZipArchive zipFile = ZipFile.Open("zipfile.zip", ZipArchiveMode.Create))
            {
                ZipArchiveEntry zipArchiveEntry = zipFile.CreateEntryFromFile("../../../GosuMonkeyManiak.jpg", "GosuMonkeyManiak.jpg");
            }
        }
    }
}
