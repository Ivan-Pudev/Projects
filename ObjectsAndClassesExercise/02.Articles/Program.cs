using System;
using System.Reflection.Metadata;

namespace _02.Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] article = Console.ReadLine().Split(", ");
            int count = int.Parse(Console.ReadLine());

            Article articles = new(article[0], article[1], article[2]);

            for (int i = 0; i < count; i++)
            {
                string[] arguments = Console.ReadLine().Split(": ");

                switch (arguments[0] + ":")
                {
                    case "Edit:":
                        string newContent = arguments[1];
                        articles.Edit(newContent);
                        break;
                    case "ChangeAuthor:":
                        string newAuthor = arguments[1];
                        articles.ChangeAuthor(newAuthor);
                        break;
                    case "Rename:":
                        string newTitle = arguments[1];
                        articles.Rename(newTitle);
                        break;
                }
            }
            Console.WriteLine(articles);
        }
    }
    public class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public void Edit(string content)
        {
            Content = content;
        }
        public void ChangeAuthor(string author)
        {
            Author = author;
        }
        public void Rename(string title)
        {
            Title = title;
        }
        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
