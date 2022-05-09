using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.page
{
    class Pay
    {
        public static void PayPage(string movieName, int ageList, List<List<int>> room, List<string> seatsList, decimal totalPriceRoom, List<string> ordersList, decimal totalPriceOrder, string name, string email, string number, string age)
        {
            decimal totalPrice = totalPriceRoom + totalPriceOrder;

            string title = "Choose a payment method:\n";
            string[] options = { "Paypal", "Ideal", "CreditcardW", "Back" };
            Pays mainMenu = new(title, options, totalPrice);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    BankLogin.BankLoginPage(movieName, ageList, room, seatsList, totalPriceRoom, ordersList, totalPriceOrder, name, email, number, age);
                    break;
                case 1:
                    Ideal.IdealPage(movieName, ageList, room, seatsList, totalPriceRoom, ordersList, totalPriceOrder, name, email, number, age);
                    break;
                case 2:
                    BankLogin.BankLoginPage(movieName, ageList, room, seatsList, totalPriceRoom, ordersList, totalPriceOrder, name, email, number, age);
                    break;
                case 3:
                    Registration.RegistrationPage(movieName, ageList, room, seatsList, totalPriceRoom, ordersList, totalPriceOrder);
                    break;
            }
        }
    }
}
