namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            Console.WriteLine(GetBooksByAuthor(db, "R"));
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var author = context.Books
                .Where(book => EF.Functions.Like(book.Author.LastName, $"{input}%"))
                .Select(book => new
                {
                    book.Title,
                    book.Author.FirstName,
                    book.Author.LastName,
                    AuthorName = book.Author.FirstName + " " + book.Author.LastName,
                    book.AuthorId

                })
                .OrderBy(book => book.AuthorId)
                .ToList();

            var result = string.Join(Environment.NewLine, author
                .Select(book => $"{book.Title} ({book.AuthorName})"));

            return result;

        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            return "a";
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var author = context.Authors
                .Where(x => x.FirstName.EndsWith(input))
                .Select(x => new
                {
                    FullName = x.FirstName + " " + x.LastName
                })
                .OrderBy(x => x.FullName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var aut in author)
            {
                sb.AppendLine($"{aut.FullName}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var targetDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(x => x.ReleaseDate.Value < targetDate)
                .Select(x => new
                {
                    Title = x.Title,
                    EditionType = x.EditionType,
                    Price = x.Price,
                    ReleaseDay = x.ReleaseDate.Value
                })
                .OrderByDescending(x => x.ReleaseDay)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
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
