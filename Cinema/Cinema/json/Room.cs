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
    class Room
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Category { get;  set; } = string.Empty;
        public decimal Price { get;  set; } = 0;

        public static List<string> orderList = new List<string>();

        public static string JsonFileName() => Path.Combine("data", "products.json");

        public static List<Room> ReadAll()
        {
            string json = File.ReadAllText(JsonFileName());
            return JsonSerializer.Deserialize<List<Room>>(json) ?? new List<Room>();
        }

        public static void WriteAll(List<Room> accounts)
        {
            string json = JsonSerializer.Serialize(accounts);
            File.WriteAllText(JsonFileName(), json);
        }
        public void Products()
        {
            var orders = ReadAll();
            foreach (var order in orders)
            {
                string price = order.Price.ToString("0.00", CultureInfo.InvariantCulture);

                orderList.Add($"{order.Name} | Category: {order.Category} | Price: {price}");
            }
            WriteAll(orders);
        }
    }
}
