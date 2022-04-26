using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.page
{
    class Login
    {
        public static void LoginPage()
        {
            string prompt = "Select you login screen\n";
            string[] options = { "Admin", "Reservation", "Back" };
            Menu mainMenu = new(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    break;
                case 1:
                    chooseScreen.chooseScreenPage();
                    break;
                case 2:
                    Home.HomePage();
                    break;
            }
        }
    }
}
