using System;

namespace HTML
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string titleOfArticle = Console.ReadLine();
            Console.WriteLine($"<h1>\n    {titleOfArticle}\n</h1>");

            string contentOfArticle = Console.ReadLine();
            Console.WriteLine($"<article>\n    {contentOfArticle}\n</article>");

            while (true)
            {
                string comment = Console.ReadLine();
                if (comment == "end of comments")
                {
                    break;
                }

                Console.WriteLine($"<div>\n    {comment}\n</div>");
            }

        }
    }
}
