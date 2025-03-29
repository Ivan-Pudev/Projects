using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Channels;

namespace AddressBookApplicationProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> contacts = new();
            Console.WriteLine("------OPTIONS------\n");
            Console.WriteLine("1 - VIEW CONTACTS");
            Console.WriteLine("2 - ADD CONTACT");
            Console.WriteLine("3 - EDIT CONTACT");
            Console.WriteLine("4 - DELETE CONTACT");
            Console.WriteLine("5 - EXIT\n");
            Console.Write("SELECT AN OPTION BY ENTERING THE FOLLOWING NUMBER: ");

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "5")
            {
                if (!CheckForCorrectOption(input))
                {
                    continue;
                }

                switch (input)
                {
                    case "1": // display a list of all contacts in the address book
                        ViewContacts(contacts);
                        break;
                    case "2": //  add a new contact to the address book
                        Console.Write("\nENTER A CONTACT - IT MUST CONTAIN 10 DIGITS: ");
                        string contact = Console.ReadLine();
                        AddContact(contacts, contact);

                        break;
                    case "3": // edit an existing contact in the address book
                        ViewContacts(contacts);
                        Console.Write("ENTER THE NUMBER OF THE CONTACT YOU WANT TO EDIT: ");
                        int index = int.Parse(Console.ReadLine());
                        EditContact(contacts, index);

                        break;
                    case "4": // delete a contact from the address book
                        ViewContacts(contacts);
                        Console.Write("ENTER THE NUMBER OF THE CONTACT YOU WANT TO DELETE: ");
                        index = int.Parse(Console.ReadLine());
                        DeleteContact(contacts, index);
                        break;
                }

                Console.Write("DO YOU WANT TO CONTINUE YES/NO: ");
                string output = Console.ReadLine();
                if (!CheckForContinue(output))
                {
                    break;
                }

                Console.Write("SELECT AN OPTION BY ENTERING THE FOLLOWING NUMBER: ");
            }

        }
        static void ViewContacts(List<string> contacts)
        {
            int count = 0;
            Console.WriteLine("\nCONTACTS:");
            if (contacts.Any())
            {
                foreach (string eachContact in contacts)
                {
                    Console.WriteLine($"{++count} - {eachContact}");
                }
            }
            else
            {
                Console.WriteLine("THERE ARE NO CONTACTS!");
            }
            Console.WriteLine();
        }
        static void AddContact(List<string> contacts, string contact)
        {
            while (contact.Length != 10)
            {
                Console.WriteLine("INVALID CONTACT\n");
                Console.Write("ENTER A CONTACT - IT MUST CONTAIN 10 DIGITS: ");
                contact = Console.ReadLine();
            }
            if (contacts.Contains(contact))
            {
                Console.WriteLine("THE CONTACT ALREADY EXISTS!\n");
            }
            else
            {
                contacts.Add(contact);
                Console.WriteLine("THE CONTACT HAS BEEN ADDED!\n");
            }
        }
        static void EditContact(List<string> contacts, int index)
        {
            if (index > 0 && index <= contacts.Count)
            {
                Console.Write("ENTER THE NEW CONTACT: ");
                string newContact = Console.ReadLine();

                contacts.Insert(index - 1, newContact);
                contacts.RemoveAt(index);
                Console.WriteLine("CONTACT EDITED SUCCESSFULLY!");
            }
            else
            {
                Console.WriteLine("INVALID CONTACT");
            }
        }
        static void DeleteContact(List<string> contacts, int index)
        {
            if (index > 0 && index <= contacts.Count)
            {
                contacts.RemoveAt(index - 1);
                Console.WriteLine("CONTACT DELETED SUCCESSFULLY!");
            }
            else
            {
                Console.WriteLine("INVALID CONTACT");
            }
        }
        static bool CheckForCorrectOption(string input)
        {
            if (input != "1" && input != "2" && input != "3" && input != "4")
            {
                Console.WriteLine("INVALID OPTION!");
                Console.Write("SELECT AN OPTION BY ENTERING THE FOLLOWING NUMBER: ");
                return false;
            }

            return true;
        }
        static bool CheckForContinue(string output)
        {
            if (output == "NO")
            {
                return false;
            }
            while (output != "YES" && output != "NO")
            {
                Console.WriteLine("INVALID OPTION!");
                Console.Write("DO YOU WANT TO CONTINUE YES/NO: ");
                output = Console.ReadLine();
            }

            return true;
        }
    }
}
