using System;
using System.Linq;

namespace P02.Articles
{
    class Articles
    {

        public string Title{ get; set; }

        public string Content { get; set; }

        public string Author{ get; set; }

        public Articles(string title, string content, string autor)
        {
           this.Title = title;

            this.Content = content;

            this.Author = autor;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author} ";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            string[] inputData = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            Articles art = new Articles(inputData[0], inputData[1], inputData[2]);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string command = Console.ReadLine();
                string[] commandArray = command.Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();


                if (commandArray[0] == "Edit")
                {
                    GetEdit(commandArray, art);
                }
                else if (commandArray[0] == "ChangeAuthor")
                {
                    GetAuthor(commandArray, art);
                }
                else if (commandArray[0] == "Rename")
                {
                    GetRename(commandArray, art);
                }
            }


            Console.WriteLine(art);
        }



        static void GetEdit(string[] inputData, Articles art)
        {
            art.Content = inputData[1];
        }

        static void GetRename(string[] inputData, Articles art)
        {
            art.Title = inputData[1];
        }

        static void GetAuthor(string[] inputData, Articles art)
        {
            art.Author = inputData[1];
        }

    }
}
