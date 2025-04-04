using System;
using System.Collections.Generic;

namespace InventoryManagementSystem.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public Dictionary<int,int> ProductsOrdered { get; set; }
        public double TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }

        public void CalculateTotalAmount()
        {

        }
        public void DisplayOrderDetails()
        {
            Console.WriteLine($"OrderID: {OrderId}, CustomerName: {CustomerName}, ProductsOrdered: {ProductsOrdered}, TotalAmount: {TotalAmount}, OrderDate: {OrderDate}.");
        }
    }
}
