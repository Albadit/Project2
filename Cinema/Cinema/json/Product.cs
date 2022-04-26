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

        public static List<string> Products()
        {
            List<string> orderList = new();

            var orders = ReadAll();
            foreach (var order in orders)
            {
                string price = order.Price.ToString("0.00", CultureInfo.InvariantCulture);
                orderList.Add($"{order.Name} | Price: {price}");
            }
            return orderList;
        }

        public static List<decimal> OrderPrice()
        {
            List<decimal> orderPriceList = new();

            var orders = ReadAll();
            foreach (var order in orders)
            {
                orderPriceList.Add(order.Price);
            }
            return orderPriceList;
        }
    }
}
