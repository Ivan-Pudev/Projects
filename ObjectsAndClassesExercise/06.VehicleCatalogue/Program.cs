using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;

namespace _06.VehicleCatalogue
{
    public class Program
    {
        static void Main()
        {
            List<Vehicle> vehicles = new();
            string command = "";
            while ((command = Console.ReadLine()) != "End")
            {
                string[] arguments = command.Split(" ");
                string type = arguments[0];
                string model = arguments[1];
                string color = arguments[2];
                double horsePower = double.Parse(arguments[3]);

                Vehicle vehicle = new(type, model, color, horsePower);
                vehicles.Add(vehicle);
            }

            while ((command = Console.ReadLine()) != "Close the Catalogue")
            {
                string vehicle = command;
                Vehicle foundVehicle = vehicles.FirstOrDefault(v => v.Model == vehicle);
                if (foundVehicle != null)
                {
                    Console.WriteLine(foundVehicle);
                }
            }

            var averageHP = vehicles
                .Where(vehicle => vehicle.Type == Type.Car)
                .Select(car => car.HorsePower)
                .DefaultIfEmpty()
                .Average();

            Console.WriteLine($"Cars have average horsepower of: {averageHP:f2}.");

            averageHP = vehicles
                .Where(vehicle => vehicle.Type == Type.Truck)
                .Select(truck => truck.HorsePower)
                .DefaultIfEmpty()
                .Average();

            Console.WriteLine($"Trucks have average horsepower of: {averageHP:f2}.");
        }
    }
    public enum Type
    {
        Car,
        Truck
    }
    public class Vehicle
    {

        public Vehicle(string type, string model, string color, double horsePower)
        {
            Type = type == "car" ? Type.Car : Type.Truck;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }
        public Type Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double HorsePower { get; set; }

        public override string ToString()
        {
            return $"Type: {Type}\n" +
                $"Model: {Model}\n" +
                $"Color: {Color}\n" +
                $"Horsepower: {HorsePower}";
        }
    }
}
