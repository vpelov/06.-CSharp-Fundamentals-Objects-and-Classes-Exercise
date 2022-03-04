using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.OrderByAge
{

    class Person
    {
        public Person(string name, string id, int age)
        {
            this.Name = name;

            this.Id = id;

            this.Age = age;
        }

        public string Name { get; set; }

        public string Id { get; set; }

        public int Age { get; set; }
    }


    internal class Program
    {
        static void Main(string[] args)
        {

            List<Person> personList = new List<Person>();

            string[] inputData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            while (inputData[0] != "End")
            {
                Person currentPerson = new Person(inputData[0], inputData[1], int.Parse(inputData[2]));

                if (personList.Count > 0)
                {

                    foreach (Person item in personList)
                    {
                        if (item.Id == inputData[1])
                        {
                            item.Name = inputData[0];
                            item.Age = int.Parse(inputData[2]);
                            inputData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                            continue;
                        }
                    }

                }
                
                    personList.Add(currentPerson);
                


                inputData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            personList = personList.OrderBy(x => x.Age).ToList();

            foreach (Person item in personList)
            {
                Console.WriteLine($"{item.Name} with ID: {item.Id} is {item.Age} years old.");
            }


        }
    }
}
