using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cinema.page
{
    class BankLogin
    {
        public static void BankLoginPage(int movieId, int timeId, int[][] yourSeats, decimal totalPriceRoom, List<string> ordersList, decimal totalPriceOrder, string[] personalInfo)
        {
            string title = "Ideal Login Page\n";
            string[] options = {"Back"};
            
            Payment mainMenu = new(title, options, movieId, timeId, yourSeats, totalPriceRoom, ordersList, totalPriceOrder, personalInfo);
            int selectedIndex = mainMenu.Run();

            if (selectedIndex == 0) Home.HomePage();
        }
    }
}
