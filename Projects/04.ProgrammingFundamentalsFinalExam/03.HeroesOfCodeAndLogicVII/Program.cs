using System;
using System.Collections.Generic;

namespace _03.HeroesOfCodeAndLogicVII
{
    internal class Program
    {
        public class Hero
        {
            public Hero(string name, int health, int mana)
            {
                Name = name;
                Health = health;
                Mana = mana;
            }
            public string Name { get; set; }
            public int Health { get; set; }
            public int Mana { get; set; }

            public override string ToString()
            {
                return $"{Name}\n"
                       + $"  HP: {Health}\n"
                       + $"  MP: {Mana}";
            }
        }

        static void Main(string[] args)
        {
            Dictionary<string, Hero> heroes = new();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string heroName = tokens[0];
                int health = int.Parse(tokens[1]);
                int mana = int.Parse(tokens[2]);

                heroes.Add(heroName, new Hero(heroName, health, mana));
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] arguments = command.Split(" - ");
                string action = arguments[0];
                string heroName = arguments[1];

                switch (action)
                {
                    case "CastSpell":
                        int neededMana = int.Parse(arguments[2]);
                        string spell = arguments[3];

                        if (heroes[heroName].Mana < neededMana)
                        {
                            Console.WriteLine($"{heroName} does not " +
                                              $"have enough MP to cast {spell}!");
                            continue;
                        }

                        heroes[heroName].Mana -= neededMana;
                        Console.WriteLine(
                            $"{heroName} has successfully cast {spell} and " +
                            $"now has {heroes[heroName].Mana} MP!");

                        break;
                    case "TakeDamage":
                        int damage = int.Parse(arguments[2]);
                        string attacker = arguments[3];

                        heroes[heroName].Health -= damage;

                        if (heroes[heroName].Health > 0)
                        {
                            Console.WriteLine(
                                $"{heroName} was hit for {damage} HP"
                                + $" by {attacker} and now has {heroes[heroName].Health} HP left!");
                        }
                        else
                        {
                            heroes.Remove(heroName);
                            Console.WriteLine($"{heroName} has been killed by {attacker}!");
                        }
                        break;
                    //case "Recharge":
                    //    int amount = int.Parse(arguments[2]);
                    //    if (heroes[heroName].Mana + amount > 200)
                    //    {
                    //        Console.WriteLine($"{heroName} recharged for {200 - heroes[heroName].Mana} MP!");
                    //        heroes[heroName].Mana = 200;
                    //        continue;
                    //    }
                    //    heroes[heroName].Mana += amount;
                    //    Console.WriteLine($"{heroName} recharged for {amount} MP!");
                    //    break;
                    //case "Heal":
                    //    amount = int.Parse(arguments[2]);

                    //    if (heroes[heroName].Health + amount> 100)
                    //    {
                    //        Console.WriteLine($"{heroName} healed for {100 - heroes[heroName].Health} HP!");
                    //        heroes[heroName].Health = 100;
                    //        continue;
                    //    }
                    //    heroes[heroName].Health += amount;
                    //    Console.WriteLine($"{heroName} healed for {amount} HP!");
                    //    break;
                    case "Recharge":
                        int rechargeAmount = int.Parse(arguments[2]);
                        int actualRecharged = Math.Min(rechargeAmount, 200 - heroes[heroName].Mana);
                        heroes[heroName].Mana += actualRecharged;

                        Console.WriteLine($"{heroName} recharged for {actualRecharged} MP!");
                        break;

                    case "Heal":
                        int healAmount = int.Parse(arguments[2]);
                        int actualHealed = Math.Min(healAmount, 100 - heroes[heroName].Health);
                        heroes[heroName].Health += actualHealed;

                        Console.WriteLine($"{heroName} healed for {actualHealed} HP!");
                        break;
                }
            }

            foreach ((string heroName, Hero hero) in heroes)
            {
                Console.WriteLine(hero);
            }
        }
    }
}
