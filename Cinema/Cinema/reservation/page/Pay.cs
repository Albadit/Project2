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
            string title = "Choose a payment method:\n";
            string[] options = { "Paypal", "Ideal", "CreditcardW", "Back" };
            Menu mainMenu = new(title, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    //Pay.PayPage(movieName, room, seatsList, totalPriceRoom, ordersList, totalPriceOrder, Name, Email, Number, Age);
                    break;
                case 1:
                    //Pay.PayPage(movieName, room, seatsList, totalPriceRoom, ordersList, totalPriceOrder, Name, Email, Number, Age);
                    break;
                case 2:
                    //Pay.PayPage(movieName, room, seatsList, totalPriceRoom, ordersList, totalPriceOrder, Name, Email, Number, Age);
                    break;
                case 3:
                    Registration.RegistrationPage(movieName, ageList, room, seatsList, totalPriceRoom, ordersList, totalPriceOrder);
                    break;
            }
        }
    }
}
