using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using static System.Console;

namespace Cinema.page
{
    class Orders
    {
        public static void OrdersPage(int movieId, int timeId, int[][] yourSeats, decimal totalPriceRoom)
        {
            List<Product> order = Product.Products();
            List<string> orderList = new();
            foreach (Product product in order)
            {
                orderList.Add($"{product.Name} | Price: {product.Price}");
            }
            orderList.Add("Back");

            string title = "Choice your drinks and food.\n";
            string[] options = orderList.ToArray();
            Order mainMenu = new(title, options, order);
            (int selectedIndex, List<string> ordersList, decimal totalPriceOrder) = mainMenu.Run();

            if (selectedIndex == options.Length - 1) Seats.SeatPage(movieId, timeId);
            else Registration.RegistrationPage(movieId, timeId, yourSeats, totalPriceRoom, ordersList, totalPriceOrder);
        }
    }
}
