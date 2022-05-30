using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using static System.Console;
using System.Globalization;

namespace Cinema
{
    class Product
    {
        public Product(int id, string name, string category, decimal price)
        {
            Id = id;
            Name = name;
            Category = category;
            Price = price;
        }

        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;

        public static string JsonFileName() => Path.Combine("data", "products.json");

        public static List<Product> ReadAll()
        {
            string json = File.ReadAllText(JsonFileName());
            return JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
        }

        public static void WriteAll(List<Product> orders)
        {
            string json = JsonSerializer.Serialize(orders);
            File.WriteAllText(JsonFileName(), json);
        }

        public static List<Product> Products()
        {
            List<Product> productId = new();

            var orders = ReadAll();
            foreach (var order in orders)
            {
                productId.AddRange(new List<Product> { new Product(order.Id, order.Name, order.Category, order.Price) });
            }
            return productId;
        }
    }
}
