namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            Console.WriteLine(GetBooksByAgeRestriction(db, "miNor"));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestrictionParse = Enum.Parse<AgeRestriction>(command, true);
            var books = context.Books
                .Where(books =>books.AgeRestriction == ageRestrictionParse)
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
    }
}
