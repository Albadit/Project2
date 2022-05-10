using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.page
{
    class Ideal
    {
        public static void IdealPage(string movieName, int ageList, List<List<int>> room, List<string> seatsList, decimal totalPriceRoom, List<string> ordersList, decimal totalPriceOrder, string name, string email, string number, string age)
        {
            string title = "Choose your bank:\n";
            string[] options = { "ABN AMRO", "ASN Bank", "bunq", "ING", "Knab", "Rabobank", "RegioBank", "Revolut", "SNS", "Svenska Handelsbanken", "Triodos Bank", "Van Lanschot", "Back"};
            Menu mainMenu = new(title, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case < 12:
                    BankLogin.BankLoginPage(movieName, ageList, room, seatsList, totalPriceRoom, ordersList, totalPriceOrder, name, email, number, age);
                    break;
                case 12:
                    Pay.PayPage(movieName, ageList, room, seatsList, totalPriceRoom, ordersList, totalPriceOrder, name, email, number, age);
                    break;
            }
        }
    }
}
