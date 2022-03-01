using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Articles2._0
{
    class Articles
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public Articles(string title, string content, string author)   // Constructor input data
        {
            this.Title = title;

            this.Content = content;

            this.Author = author;
        }

        public override string ToString()        // override metod for print
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            int numberArticles = int.Parse(Console.ReadLine());
            List<Articles> artList = new List<Articles>();

            for (int i = 0; i < numberArticles; i++)
            {
                string[] inputData = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                Articles art = new Articles(inputData[0], inputData[1], inputData[2]);
                artList.Add(art);
            }

            string command = Console.ReadLine();

            if (command == "title")
            {
                artList = artList.OrderBy(s => s.Title).ToList();
            }
            else if (command == "content")
            {
                artList = artList.OrderBy(s => s.Content).ToList();
            }
            else if (command == "author")
            {
                artList = artList.OrderBy(s => s.Author).ToList();
            }

            foreach (Articles item in artList)
            {
                Console.WriteLine(item);
            }

        }
    }
}
