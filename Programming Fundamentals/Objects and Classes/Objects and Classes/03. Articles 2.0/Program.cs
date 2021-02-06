using System;
using System.Collections.Generic;
using System.Linq;

namespace Article_Second
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Article> list = new List<Article>();

            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                Article myArticle = new Article(tokens[0], tokens[1], tokens[2]);
                list.Add(myArticle);


            }

            var criteria = Console.ReadLine();
            List<Article> sortedArticles = new List<Article>();

            if (criteria == "title")
            {
                sortedArticles = list.OrderBy(x => x.Title).ToList();
            }

            else if (criteria == "content")
            {
                sortedArticles = list.OrderBy(x => x.Content).ToList();
            }

            else
            {
                sortedArticles = list.OrderBy(x => x.Author).ToList();
            }

            foreach (var item in sortedArticles)
            {
                Console.WriteLine(item);
            }
        }

        class Article
        {
            public Article(string title, string content, string author)
            {
                this.Title = title;
                this.Content = content;
                this.Author = author;
            }

            public string Title { get; set; }

            public string Content { get; set; }

            public string Author { get; set; }

            public override string ToString()
            {
                return $"{this.Title} - {this.Content}: {this.Author}";
            }
        }
    }
}