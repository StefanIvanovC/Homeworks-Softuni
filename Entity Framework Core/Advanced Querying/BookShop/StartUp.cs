namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            Console.WriteLine(GetBooksByCategory(db, "horror mystery drama"));
        }


        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToLower())
                .ToArray();

            var books = context.Books
                .Include(x => x.BookCategories)
                .ThenInclude(x => x.Category)
                .ToArray()
                .Where(x => x.BookCategories
                    .Any(category => categories.Contains(category.Category.Name.ToLower())))
                .Select(x => x.Title)
                .OrderBy(title => title)
                .ToArray();

            var result = string.Join(Environment.NewLine, books);

            return result;
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestrictionParse = Enum.Parse<AgeRestriction>(command, true);
            var books = context.Books
                .Where(books => books.AgeRestriction == ageRestrictionParse)
                .Select(books => books.Title)
                .OrderBy(title => title)
                .ToArray();


            var result = "";

            foreach (var bookTitle in books)
            {
                result = string.Join(Environment.NewLine, books);
            }

            return result;

        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.EditionType == EditionType.Gold &&
                                       x.Copies < 5000)
                .Select(x => new
                {
                    Title = x.Title,
                    Id = x.BookId

                })
                .OrderBy(x => x.Id)
                .ToArray();

            var result = string.Join(Environment.NewLine,
                                books.Select(x => x.Title));

            return result;

        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var booksWithPrice = context.Books
                .Where(x => x.Price > 40)
                .Select(x => new
                {
                    Title = x.Title,
                    Price = x.Price
                })
                .OrderByDescending(x => x.Price)
                .ToArray();


            var sb = new StringBuilder();

            foreach (var book in booksWithPrice)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();

        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year != year && x.ReleaseDate.HasValue)
                .Select(x => new
                {
                    Title = x.Title,
                    BookById = x.BookId
                })
                .OrderBy(x => x.BookById)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title}");
            }

            return sb.ToString().TrimEnd();

        }
    }
}
