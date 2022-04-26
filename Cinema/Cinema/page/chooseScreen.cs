using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.page
{
    class chooseScreen
    {
        public static void chooseScreenPage()
        {
            string title = "What would you like to do?\n";
            string[] options = { "Check Reservation", "Cancel Reservation", "Back" };
            Menu mainMenu = new(title, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    loginScreen.loginScreenPage();
                    break;
                case 1:
                    CancelReservationPage.cancelReservationPage();
                    break;
                case 2:
                    Login.LoginPage();
                    break;     
            }
        }
    }
}
