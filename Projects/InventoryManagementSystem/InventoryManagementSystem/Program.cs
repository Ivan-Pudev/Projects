using System;
using System.Collections.Generic;
using System.Linq;
using InventoryManagementSystem.Models;
namespace InventoryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Supplier> suppliers = new();
            Inventory inventory = new();

            Console.WriteLine("----Welcome to the inventory management system!----");

            string choice = string.Empty;
            while (choice != "end")
            {
                Console.WriteLine("1 - Product management!");
                Console.WriteLine("2 - Stock management!");
                Console.WriteLine("3 - Supplier management!");
                Console.WriteLine("4 - Sales and order processing!");
                Console.WriteLine("5 - Reports and analytics!");
                Console.WriteLine("6 - Search and filtering!");
                Console.Write("Enter the corresponding number to your action: ");
                string numberChoice = Console.ReadLine();

                switch (numberChoice)
                {
                    case "1":
                        Console.WriteLine("A - Add products!");
                        Console.WriteLine("B - Edit/Update products!");
                        Console.WriteLine("C - Delete products!");
                        Console.WriteLine("D - Categorize products!");
                        Console.Write("Choose your action: ");
                        char action = char.Parse(Console.ReadLine().ToUpper());
                        Console.Clear();

                        switch (action)
                        {

                            case 'A':
                                Console.Write("Enter ID: ");
                                int iD = int.Parse(Console.ReadLine());
                                Console.Write("Enter name: ");
                                string name = Console.ReadLine();
                                Console.Write("Enter category: ");
                                string category = Console.ReadLine();
                                Console.Write("Enter price: ");
                                double price = double.Parse(Console.ReadLine());
                                Console.Write("Enter quantity: ");
                                int quantity = int.Parse(Console.ReadLine());
                                Console.Write("Enter supplier ID: ");
                                int supplierId = int.Parse(Console.ReadLine());

                                Product product = new(iD, name, category, price, quantity, supplierId);
                                inventory.AddProduct(product);
                                break;
                            case 'B':
                                if (ViewProductList(inventory)) break;

                                Console.WriteLine("Enter the ID you want to update");
                                iD = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter the section you want to update");
                                string section = Console.ReadLine();

                                if (section == "Name")
                                {
                                    Console.WriteLine("Enter new name.");
                                    name = Console.ReadLine();
                                    Console.WriteLine($"{inventory.Products[iD].Name} -> {name}");
                                    inventory.Products[iD].Name = name;
                                }
                                else if (section == "Category")
                                {
                                    Console.WriteLine("Enter new category.");
                                    category = Console.ReadLine();
                                    Console.WriteLine($"{inventory.Products[iD].Category} -> {category}");
                                    inventory.Products[iD].Category = category;
                                }
                                else if (section == "Price")
                                {
                                    Console.WriteLine("Enter new price.");
                                    price = double.Parse(Console.ReadLine());
                                    Console.WriteLine($"{inventory.Products[iD].Price} -> {price}");
                                    inventory.Products[iD].Price = price;
                                }
                                else if (section == "Quantity")
                                {
                                    Console.WriteLine("Enter new quantity.");
                                    quantity = int.Parse(Console.ReadLine());
                                    Console.WriteLine($"{inventory.Products[iD].Quantity} -> {quantity}");
                                    inventory.Products[iD].Quantity = quantity;
                                }
                                else if (section == "SupplierId")
                                {
                                    Console.WriteLine("Enter new supplier Id.");
                                    supplierId = int.Parse(Console.ReadLine());
                                    Console.WriteLine($"{inventory.Products[iD].SupplierId} -> {supplierId}");
                                    inventory.Products[iD].SupplierId = supplierId;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Choice.");
                                }
                                break;
                            case 'C':
                                if (ViewProductList(inventory)) break;

                                Console.Write("Enter ID: ");
                                iD = int.Parse(Console.ReadLine());
                                inventory.RemoveProduct(iD);
                                break;
                            case 'D':
                                inventory.CategorizeProducts();
                                break;
                            default:
                                Console.WriteLine("Invalid choice.");
                                break;
                        }

                        break;
                    case "2":
                        Console.WriteLine("A - Check stock levels!");
                        Console.WriteLine("B - Low stock alerts!");
                        Console.WriteLine("C - Adjust stocks!");
                        Console.Write("Choose your action: ");
                        action = char.Parse(Console.ReadLine().ToUpper());
                        Console.Clear();

                        switch (action)
                        {
                            case 'A':
                                if (inventory.Products.Count == 0)
                                {
                                    Console.WriteLine("No stocks available.");
                                    break;
                                }
                                Console.WriteLine("Quantities");
                                foreach (Product value in inventory.Products.Values)
                                {
                                    Console.WriteLine($"{value.Name} - {value.Quantity}");
                                }
                                break;
                            case 'B':
                                if (inventory.Products.Count == 0)
                                {
                                    Console.WriteLine("There are no products.");
                                    break;
                                }

                                int lowStockQuantityAlert = 5;
                                foreach (Product productValue in inventory.Products.Values)
                                {
                                    if (productValue.Quantity < lowStockQuantityAlert)
                                    {
                                        Console.WriteLine($"LOW STOCK ALERT: Product {productValue.Name} (ID: {productValue.Id}) " +
                                                          $"has only {productValue.Quantity} units left! \r\nConsider restocking soon.");
                                    }
                                }
                                break;
                            case 'C':
                                Console.WriteLine("1 - Increase Stock");
                                Console.WriteLine("2 - Decrease Stock");
                                Console.WriteLine("3 - Track Adjustment History");
                                int decision = int.Parse(Console.ReadLine());

                                if (ViewProductList(inventory)) break;

                                Console.WriteLine("Enter ID to update the stock.");
                                int iD = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter the stock.");
                                int quantityUpdate = int.Parse(Console.ReadLine());
                                if (decision == 1)
                                {
                                    inventory.Products[iD].Restock(quantityUpdate);
                                }
                                else if (decision == 2)
                                {
                                    inventory.Products[iD].Sell(quantityUpdate);
                                }
                                else if (decision == 3)
                                {

                                }
                                else
                                {
                                    Console.WriteLine("Invalid choice.");
                                }
                                break;
                                break;
                            default:
                                Console.WriteLine("Invalid choice.");
                                break;
                        }
                        break;
                    case "3":
                        Console.WriteLine("A - Add/Edit supplier details!");
                        Console.WriteLine("B - Link products to supplier!");
                        Console.WriteLine("C - Purchase Orders!");
                        Console.Write("Choose your action: ");
                        action = char.Parse(Console.ReadLine().ToUpper());
                        Console.Clear();

                        switch (action)
                        {
                            case 'A':
                                Console.Write("Enter ID: ");
                                int supplierId = int.Parse(Console.ReadLine());
                                Console.Write("Enter name: ");
                                string supplierName = Console.ReadLine();
                                Console.Write("Enter contact: ");
                                string supplierContact = Console.ReadLine();
                                Console.Write("Enter address: ");
                                string supplierAddress = Console.ReadLine();

                                Supplier supplier = new Supplier(supplierId, supplierName, supplierContact, supplierAddress);
                                suppliers.Add(supplier);
                                break;
                            case 'B':
                                
                                break;
                            case 'C':
                                break;
                            default:
                                Console.WriteLine("Invalid choice.");
                                break;
                        }
                        break;
                    case "4":
                        Console.WriteLine("A - Create sales order!");
                        Console.WriteLine("B - Update stock on sale!");
                        Console.WriteLine("C - Generate Invoices/Receipts!");
                        Console.WriteLine("D - Manage returns!");
                        action = char.Parse(Console.ReadLine().ToUpper());
                        Console.Clear();

                        switch (action)
                        {
                            case 'A':
                                break;
                            case 'B':
                                break;
                            case 'C':
                                break;
                            case 'D':
                                break;
                            default:
                                Console.WriteLine("Invalid choice.");
                                break;
                        }
                        break;
                    case "5":
                        Console.WriteLine("A - Stock report!");
                        Console.WriteLine("B - Sales report!");
                        Console.WriteLine("C - Supplier report!");
                        Console.WriteLine("D - Predictive analysis!");
                        action = char.Parse(Console.ReadLine().ToUpper());
                        Console.Clear();

                        switch (action)
                        {
                            case 'A':
                                break;
                            case 'B':
                                break;
                            case 'C':
                                break;
                            case 'D':
                                break;
                            default:
                                Console.WriteLine("Invalid choice.");
                                break;
                        }
                        break;
                    case "6":
                        Console.WriteLine("A - Search products by name and ID!");
                        Console.WriteLine("B - Filter by category and supplier!");
                        Console.WriteLine("C - Sort by price, stock level or popularity!");
                        action = char.Parse(Console.ReadLine().ToUpper());
                        Console.Clear();

                        switch (action)
                        {
                            case 'A':
                                break;
                            case 'B':
                                break;
                            case 'C':
                                break;
                            default:
                                Console.WriteLine("Invalid choice.");
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                Console.WriteLine("\nType 'end' to exit or press Enter to continue...");
                choice = Console.ReadLine().ToLower();
            }
        }

        private static bool ViewProductList(Inventory inventory)
        {
            if (inventory.Products.Count == 0)
            {
                Console.WriteLine("There are no products.");
                return true;
            }

            foreach (Product productValue in inventory.Products.Values)
            {
                productValue.DisplayProductDetails();
            }

            return false;
        }
    }
}
