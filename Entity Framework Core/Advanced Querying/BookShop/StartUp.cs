namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            Console.WriteLine(GetBooksByPrice(db));
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


        //public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        //{
        //    //var enumParse = Enum.Parse<relea>

        //    //var books = context.Books
        //    //    .Where(x => x.ReleaseDate != year)
        //    //    .Select 
        //}
    }
}
