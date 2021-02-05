using System;

namespace ArticlesFin
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            Article article = new Article(input[0], input[1], input[2]);

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] cmdTokens = Console.ReadLine().Split(new string[] { ": " }, StringSplitOptions.RemoveEmptyEntries);
                string cmd = cmdTokens[0];

                if (cmd == "Edit")
                {
                    article.Edit(cmdTokens[1]);
                }
                else if (cmd == "ChangeAuthor")
                {
                    article.ChangeAuthor(cmdTokens[1]);
                }
                else
                {
                    article.Rename(cmdTokens[1]);
                }
            }
            Console.WriteLine(article);
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

        public void Edit(string content)
        {
            this.Content = content;
        }

        public void ChangeAuthor(string author)
        {
            this.Author = author;
        }

        public void Rename(string title)
        {
            this.Title = title;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
}