using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagementSystem.Models
{
    public class Inventory
    {
        public Dictionary<int, Product> Products { get; set; } = new();

        public void AddProduct(Product product)
        {
            if (!Products.ContainsKey(product.Id))
            {
                Products.Add(product.Id, product);
                Console.WriteLine("Successfully added product.");
            }
            else
            {
                Console.WriteLine("The product has already been added.");
            }
        }
        public void RemoveProduct(int productId)
        {
            if (Products.Remove(productId))
            {
                Console.WriteLine("Successfully removed product.");
            }
            else
            {
                Console.WriteLine("There is no product with this ID.");
            }
        }
        public void UpdateStock(int productId, int newStock)
        {
            if (Products.ContainsKey(productId))
            {
                Products[productId].Quantity = newStock;
                Console.WriteLine("Successfully updated product.");
            }
            else
            {
                Console.WriteLine("There is no product with this ID.");
            }
        }
        public int GetProductId(int productId)
        {
            return 0;
        }

        public string SearchProducts(string keyword)
        {
            return null;
        }
        public void CategorizeProducts()
        {
            var grouped = Products.Values.GroupBy(p => p.Category);
            foreach (var category in grouped)
            {
                Console.WriteLine($"\nCategory: {category.Key}");
                foreach (var product in category)
                {
                    product.DisplayProductDetails();
                }
            }
        }
    }
}
