using System;
namespace InventoryManagementSystem.Models
{
    public class Supplier
    {
        public Supplier(int supplierId,string name, string contact, string address)
        {
            SupplierId = supplierId;
            Name = name;
            Contact = contact;
            Address = address;
        }

        

        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }

        public void DisplaySupplierInfo()
        {
            Console.WriteLine($"SupplierID: {SupplierId}, Name: {Name}, Contact: {Contact}, Address: {Address}.");
        }
    }
}
