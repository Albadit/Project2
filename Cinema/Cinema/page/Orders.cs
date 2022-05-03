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
        public static void OrdersPage(string movieName, List<List<int>> room)
        {
            List<string> orderList = Product.Products();
            orderList.Add("Back");

            string title = "Choice your drinks and food\n";
            string[] options = orderList.ToArray();
            Order mainMenu = new(title, options);
            int selectedIndex = mainMenu.Run();

            if (selectedIndex == options.Length - 1)
            {
                Seats.SeatPage(movieName);
            }
        }
    }
}
