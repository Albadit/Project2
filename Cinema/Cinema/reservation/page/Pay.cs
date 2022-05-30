using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.page
{
    class Pay
    {
        public static void PayPage(int movieId, int timeId, int[][] yourSeats, decimal totalPriceRoom, List<string> ordersList, decimal totalPriceOrder, string[] personalInfo)
        {
            decimal totalPrice = totalPriceRoom + totalPriceOrder;

            string title = "Choose a payment method:\n";
            string[] options = { "Paypal", "Ideal", "Creditcard", "Back" };
            Pays mainMenu = new(title, options, totalPrice);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    BankLogin.BankLoginPage(movieId, timeId, yourSeats, totalPriceRoom, ordersList, totalPriceOrder, personalInfo);
                    break;
                case 1:
                    Ideal.IdealPage(movieId, timeId, yourSeats, totalPriceRoom, ordersList, totalPriceOrder, personalInfo);
                    break;
                case 2:
                    BankLogin.BankLoginPage(movieId, timeId, yourSeats, totalPriceRoom, ordersList, totalPriceOrder, personalInfo);
                    break;
                case 3:
                    Registration.RegistrationPage(movieId, timeId, yourSeats, totalPriceRoom, ordersList, totalPriceOrder);
                    break;
            }
        }
    }
}
