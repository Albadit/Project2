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
        public static void BankLoginPage(int movieId, int[][] yourSeats, decimal totalPriceRoom, List<string> ordersList, decimal totalPriceOrder, string[] information)
        {
            string title = "Ideal Login Page\n";
            string[] options = {"Back"};
            
            Payment mainMenu = new(title, options, movieId, yourSeats, totalPriceRoom, ordersList, totalPriceOrder, information);
            int selectedIndex = mainMenu.Run();

            if (selectedIndex == 0) Home.HomePage();
        }
    }
}
