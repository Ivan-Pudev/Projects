using System;

namespace InventoryManagementSystem.Models
{
    public class SalesTransaction
    {
        public int TransactionId { get; set; }
        public int ProductId { get; set; }
        public int QuantitySold { get; set; }
        public double TotalPrice { get; set; }
        public DateTime SalesDate { get; set; }

        public double CalculateTotal()
        {
            return TotalPrice * QuantitySold;
        }
        public void DisplayTransaction()
        {
            Console.WriteLine($"TransactionId: {TransactionId}, ProductId: {ProductId}, QuantitySold: {QuantitySold}, TotalPrice: {TotalPrice:F2}, SalesDate: {SalesDate}.");
        }
    }
}
