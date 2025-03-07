using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace _02.Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Article> list = new ();
            for (int i = 0; i < count; i++)
            {
                string[] arguments = Console.ReadLine().Split(", ");
                Article article = new(arguments[0], arguments[1], arguments[2]);
                list.Add(article);
            }
            foreach (Article article in list)
            Console.WriteLine(article);
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

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
