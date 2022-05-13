using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.page
{
    class Ideal
    {
<<<<<<< HEAD:Cinema/Cinema/reservation/page/Ideal.cs
        public static void IdealPage(int movieId, int timeId, int[][] yourSeats, decimal totalPriceRoom, List<string> ordersList, decimal totalPriceOrder, string[] personalInfo)
=======
        public  static void IdealPage(string filmName)
>>>>>>> parent of 5579f1c (fix all bugs):Cinema/Cinema/page/Ideal.cs
        {
            string title = "Choose your bank:\n";
            string[] options = { "ABN AMRO", "ASN Bank", "bunq", "ING", "Knab", "Rabobank", "RegioBank", "Revolut", "SNS", 
                "Svenska Handelsbanken", "Triodos Bank", "Van Lanschot", "Back"};
            Menu mainMenu = new(title, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case < 12:
<<<<<<< HEAD:Cinema/Cinema/reservation/page/Ideal.cs
                    BankLogin.BankLoginPage(movieId, timeId, yourSeats, totalPriceRoom, ordersList, totalPriceOrder, personalInfo);
                    break;
                case 12:
                    Pay.PayPage(movieId, timeId, yourSeats, totalPriceRoom, ordersList, totalPriceOrder, personalInfo);
=======
                    idealLogin.idealLoginPage(filmName);
                    break;
                case 12:
                    Pay.PayPage(filmName);
>>>>>>> parent of 5579f1c (fix all bugs):Cinema/Cinema/page/Ideal.cs
                    break;
            }
        }
    }
}
