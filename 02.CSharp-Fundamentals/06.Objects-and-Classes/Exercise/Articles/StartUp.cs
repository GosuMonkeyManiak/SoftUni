using System;
using System.Linq;

namespace Articles
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string inPut = Console.ReadLine();

            string[] splitInput = inPut
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int n = int.Parse(Console.ReadLine());

            Article article = new Article(splitInput[0],splitInput[1],splitInput[2]);

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(": ")
                    .ToArray();

                switch (command[0].ToLower())
                {
                    case "edit":
                        article.Edit(command[1]);
                        break;

                    case "changeauthor":
                        article.ChangeAuthor(command[1]);
                        break;

                    case "rename":
                        article.Rename(command[1]);
                        break;
                }
            }

            Console.WriteLine(article.ToString());
        }
    }
}
