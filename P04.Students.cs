using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.Students
{
    class Students
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Grade { get; set; }

        public Students(string firstName, string lastName, double grade)
        {
            this.FirstName = firstName;

            this.LastName = lastName;

            this.Grade = grade;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}: {this.Grade:f2}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Students> allStudents = new List<Students>();

            int numberStudents = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberStudents; i++)
            {
                string[] inputData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                Students student = new Students(inputData[0], inputData[1], double.Parse(inputData[2]));
                allStudents.Add(student);
            }

            allStudents = allStudents.OrderByDescending(student => student.Grade).ToList();

            foreach (Students item in allStudents)
            {
                Console.WriteLine(item);
            }

        }
    }
}
