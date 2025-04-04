using System;

namespace InventoryManagementSystem.Models
{
    public class Product
    {
        public Product(int id, string name, string category, double price, int quantity, int supplierId)
        {
            Id = id;
            Name = name;
            Category = category;
            Price = price;
            Quantity = quantity;
            SupplierId = supplierId;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int SupplierId { get; set; }

        public void Restock(int amount)
        {
            Quantity += amount;
        }
        public void Sell(int quantity)
        {
            Quantity -= quantity;
        }
        public void DisplayProductDetails()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Category: {Category}, Price: {Price:f2}, Quantity: {Quantity}, SupplierId: {SupplierId}");
        }
    }
}
