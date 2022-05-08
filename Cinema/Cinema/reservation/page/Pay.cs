using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.page
{
    class Pay
    {
        public static void PayPage(string movieName, List<List<int>> room, List<string> seatsList, decimal totalPriceRoom, List<string> ordersList, decimal totalPriceOrder)
        {
            string title = "Choose a payment method:\n";
            string[] options = { "Paypal", "Ideal", "CreditcardW", "Back" };
            Menu mainMenu = new(title, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    //Orders.OrdersPage(movieName, room, totalPriceRoom);
                    break;
            }
        }
    }
}
