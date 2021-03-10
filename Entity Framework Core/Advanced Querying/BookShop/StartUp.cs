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

            Console.WriteLine(GetMostRecentBooks(db)); 
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    x.Name,
                    Books = x.CategoryBooks.Select(b => new
                    {
                        b.Book.Title,
                        b.Book.ReleaseDate.Value
                    })
                    .OrderByDescending(b => b.Value)
                    .Take(3)
                    .ToList()
                })
                .OrderBy(x => x.Name)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var catBook in categories)
            {
                sb.AppendLine($"--{catBook.Name}");

                foreach (var book in catBook.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();


        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categoryes = context.Categories
                .Select(x => new
                {
                    x.Name,
                    Profit = x.CategoryBooks.Sum(b => b.Book.Price * b.Book.Copies)
                })
                .OrderByDescending(x => x.Profit)
                .ThenBy(x => x.Name)
                .ToList();

            var result = string.Join(Environment.NewLine, categoryes
                .Select(categoryes => $"{categoryes.Name} ${categoryes.Profit:F2}"));

            return result;
        }
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var autors = context.Authors
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    TotalCopies = x.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(x => x.TotalCopies)
                .ToList();
            var sb = new StringBuilder();

            foreach (var aut in autors)
            {
                sb.AppendLine($"{aut.FirstName} {aut.LastName} - {aut.TotalCopies}");
            }

            return sb.ToString().TrimEnd();
        }


        //public static int CountBooks(BookShopContext context, int lengthCheck)
        //{
        //    var books = context.Books
        //        .Where(x => x.Title.Length > lengthCheck)
        //        .Select(x => new
        //        {
        //            CountOfBooks = x.Title.Count()
        //        })
        //        .ToList();

        //    return books;
        //}

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

        //public static string GetBookTitlesContaining(BookShopContext context, string input)
        //{
        //    var titlesOfBooks = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
        //        .Select(x => x.ToLower())
        //        .ToArray();

        //    var books = context.Books
        //                        //.Any(category => categories.Contains(category.Category.Name.ToLower())))b 
        //       .Where(context.Books
        //       x => x.Any(x => titlesOfBooks.Contains(x.Title.ToLower())))
        //       .Select(x => x.Title)
        //       .OrderBy(title => title)
        //       .ToArray();

        //    return "a";
        //}

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
