using System;
using System.Collections.Generic;
using System.Linq;

namespace ArticleTwoPointZero
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int numberArticles = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>(numberArticles);

            for (int i = 0; i < numberArticles; i++)
            {
                string[] inPut = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Article newArticle = new Article(inPut[0], inPut[1], inPut[2]);

                articles.Add(newArticle);
            }

            string condition = Console.ReadLine();

            if (condition == "title")
            {
                for (int i = 0; i < articles.Count; i++)
                {
                    for (int j = 0; j < articles.Count - 1; j++)
                    {
                        if (articles[j].Title.CompareTo(articles[j + 1].Title) == 1)
                        {
                            Article temp = articles[j];
                            articles[j] = articles[j + 1];
                            articles[j + 1] = temp;
                        }
                    }
                }
            }
            else if (condition == "content")
            {
                for (int i = 0; i < articles.Count; i++)
                {
                    for (int j = 0; j < articles.Count - 1; j++)
                    {
                        if (articles[j].Content.CompareTo(articles[j + 1].Content) == 1)
                        {
                            Article temp = articles[j];
                            articles[j] = articles[j + 1];
                            articles[j + 1] = temp;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < articles.Count; i++)
                {
                    for (int j = 0; j < articles.Count - 1; j++)
                    {
                        if (articles[j].Author.CompareTo(articles[j + 1].Author) == 1)
                        {
                            Article temp = articles[j];
                            articles[j] = articles[j + 1];
                            articles[j + 1] = temp;
                        }
                    }
                }
            }


            foreach (var item in articles)
            {
                Console.WriteLine(item.ToString());
            }
            
        }
    }
}
