using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.OrderByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string command = "";
            while ((command = Console.ReadLine()) != "End")
            {
                string[] arguments = command.Split(" ");
                string name = arguments[0];
                string iD = arguments[1];
                int age = int.Parse(arguments[2]);
                Person person = new(name, iD, age);
                if (people.Any(p => p.Id == iD))
                {
                    person.Name = name;
                    person.Age = age;
                }
                people.Add(person);
            }
            people = people.OrderBy(p => p.Age).ToList();
            
            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
    public class Person
    {
        public Person(string name, string id, int age)
        {
            Name = name;
            Id = id;
            Age = age;
        }
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} with ID: {Id} is {Age} years old.";
        }
    }
}
