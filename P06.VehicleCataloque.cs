using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.VehicleCataloque
{

    class Vehicle
    {
        public Vehicle(string type, string model, string color, int hp)
        {
            this.Type = type;

            this.Model = model;

            this.Color = color;

            this.HorsePower = hp;
        }

        public string Type { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public int HorsePower { get; set; }


        public override string ToString()
        {
            string vehicleStr = $"Type: {(this.Type == "car" ? "Car" : "Truck")}{Environment.NewLine}" +
                                 $"Model: {this.Model}{Environment.NewLine}" +
                                 $"Color: {this.Color}{Environment.NewLine}" +
                                 $"Horsepower: {this.HorsePower}";

            return vehicleStr;
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicleList = new List<Vehicle>();

            string[] commandArray = Console.ReadLine().Split(' ').ToArray();

            while (commandArray[0] != "End")
            {
                Vehicle currentVehicle = new Vehicle(commandArray[0], commandArray[1], commandArray[2], int.Parse(commandArray[3]));

                vehicleList.Add(currentVehicle);

                commandArray = Console.ReadLine().Split(' ').ToArray();
            }


            string command = Console.ReadLine();

            while (command != "Close the Catalogue")
            {
                foreach (Vehicle item in vehicleList)
                {
                    if (item.Model == command)
                    {
                        Console.WriteLine(item);
                    }
                }

                command = Console.ReadLine();
            }


            List<Vehicle> carList = vehicleList.Where(x => x.Type == "car").ToList();
            if (carList.Count > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {carList.Average(x => x.HorsePower):f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            }

            List<Vehicle> truckList = vehicleList.Where(x => x.Type == "truck").ToList();
            if (truckList.Count > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {truckList.Average(x => x.HorsePower):f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }

        }
    }
}
