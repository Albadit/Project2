
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.page
{
    class Registration
    {
        public static void RegistrationPage(string movieName, int ageList, List<List<int>> room, List<string> seatsList, decimal totalPriceRoom, List<string> ordersList, decimal totalPriceOrder)
        {
            string title = "Fill in your info.\n";
            string[] options = { "Payment", "Back" };
            Registrar mainMenu = new(title, options, ageList);
            (int selectedIndex, string name, string email, string number, string age) = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Pay.PayPage(movieName, ageList, room, seatsList, totalPriceRoom, ordersList, totalPriceOrder, name, email, number, age);
                    break;
                case 1:
                    Orders.OrdersPage(movieName, ageList, room, seatsList, totalPriceRoom);
                    break;
            }
        }
    }
}