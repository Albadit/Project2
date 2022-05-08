
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.page
{
    class Registration
    {
        public static void RegistrationPage(string movieName, List<List<int>> room, List<string> seatsList, decimal totalPriceRoom, List<string> ordersList, decimal totalPriceOrder)
        {
            string title = "Fill in your info.\n";
            string[] options = { "Payment", "Back" };
            Registrar mainMenu = new(title, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Pay.PayPage(movieName, room, seatsList, totalPriceRoom, ordersList, totalPriceOrder);
                    break;
                case 3:
                    Seats.SeatPage(movieName);
                    break;
            }
        }
    }
}