using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DirectoryTraversal
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string directoryPath = @"D:\Software University\SoftUni\04.CSharp-Advanced\04.Streams-Files-and-Directories\Exercise\DirectoryTraversal";
            string[] fileNames = Directory.GetFiles(directoryPath);

            Dictionary<string, List<Files>> files = new Dictionary<string, List<Files>>();

            foreach (var file in fileNames)
            {
                string extension = file.Substring(file.LastIndexOf('.'));
                string fullName = file.Substring(file.LastIndexOf('\\') + 1);

                FileInfo size = new FileInfo($"{directoryPath}\\{fullName}");
                decimal sizes = size.Length;

                if (!files.ContainsKey(extension))
                {
                    files.Add(extension, new List<Files>());
                    files[extension].Add(new Files() 
                    {
                        FullName = fullName,
                        Size = sizes
                    });
                }
                else
                {
                    files[extension].Add(new Files()
                    {
                        FullName = fullName,
                        Size = sizes
                    });
                }


            }

            files = files
                 .OrderByDescending(x => x.Value.Count)
                 .ThenBy(x => x.Key)
                 .ToDictionary(x => x.Key, y => y.Value);

            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"outPut.txt");

            List<string> lines = new List<string>();

            foreach (var file in files)
            {
                lines.Add(file.Key);
                foreach (var item in file.Value.OrderBy(x => x.Size))
                {
                    lines.Add($"--{item.FullName} - {item.Size:f3}kb");
                }
            }

            File.WriteAllLines(path, lines);
        }
    }
}
