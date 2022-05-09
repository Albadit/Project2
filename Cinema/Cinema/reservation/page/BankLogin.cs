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
        public static void BankLoginPage(string movieName, int ageList, List<List<int>> room, List<string> seatsList, decimal totalPriceRoom, List<string> ordersList, decimal totalPriceOrder, string name, string email, string number, string age)
        {
            string title = "Ideal Login Page\n";
            string[] options = {"Back"};
            
            Paymentlogin mainMenu = new(title, options, name, email, number, age);
            int selectedIndex = mainMenu.Run();

            if (selectedIndex == 0) Home.HomePage();
        }
    }
}
