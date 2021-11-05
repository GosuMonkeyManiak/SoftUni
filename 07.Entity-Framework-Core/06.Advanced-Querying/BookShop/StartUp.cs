using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using BookShop.Models;
using BookShop.Models.Enums;

namespace BookShop
{
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            string command = Console.ReadLine();
            //int year = int.Parse(Console.ReadLine());

            string result = GetBooksByAuthor(db, command);

            Console.WriteLine(result);
            //Console.WriteLine(result.Length);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var booksWithSomeAgeRestriction = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .OrderBy(b => b.Title)
                .Select(b => new
                {
                    BookTittle = b.Title
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in booksWithSomeAgeRestriction)
            {
                sb.AppendLine(book.BookTittle);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBooks = context.Books
                .Where(b => b.Copies < 5000 && b.EditionType == EditionType.Gold)
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in goldenBooks)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var booksByPrice = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    Title = b.Title,
                    Price = b.Price
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in booksByPrice)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var booksNotReleased = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in booksNotReleased)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            List<string> categories = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> booksByCategoryOnlyTitle = new List<string>();

            foreach (var category in categories)
            {
                var currentCategory = context.Categories
                    .Where(c => c.Name.ToLower() == category.ToLower())
                    .SelectMany(c => c.CategoryBooks
                        .Select(cb => cb.Book))
                    .Select(b => b.Title)
                    .ToList();

                booksByCategoryOnlyTitle.AddRange(currentCategory);
            }

            StringBuilder sb = new StringBuilder();

            foreach (var title in booksByCategoryOnlyTitle.OrderBy(t => t))
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", null);

            var booksReleasedBeforeSomeDate = context.Books
                .Where(b => b.ReleaseDate < dateTime)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    Title = b.Title,
                    EditionType = b.EditionType,
                    Price = b.Price
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in booksReleasedBeforeSomeDate)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authorsEndsWith = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => a.FirstName + " " + a.LastName);

            StringBuilder sb = new StringBuilder();

            foreach (var fullName in authorsEndsWith.OrderBy(a => a))
            {
                sb.AppendLine(fullName);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var booksWhichContainsInPut = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title);

            StringBuilder sb = new StringBuilder();

            foreach (var title in booksWhichContainsInPut)
            {
                sb.Append($"{title}\r\n");
            }

            return sb.ToString().Trim();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var booksWrittenByAuthor = context.Authors
                .Where(a => a.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(a => new
                {
                    AuthorFullName = a.FirstName + " " + a.LastName,
                    BookTitles = a.Books.
                        OrderBy(b => b.BookId).
                        Select(b => b.Title)
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var authorBooks in booksWrittenByAuthor)
            {
                foreach (var title in authorBooks.BookTitles)
                {
                    sb.AppendLine($"{title} ({authorBooks.AuthorFullName})");
                }
            }

            return sb.ToString().Trim();

        }
    }
}
