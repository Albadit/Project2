using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.page
{
    class chooseScreen
    {
        public void chooseScreenPage()
        {
            string title = "What would you like to do?\n";
            string[] options = { "Check Reservation", "Cancel Reservation", "Back" };
            Menu mainMenu = new Menu(title, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    loginScreen myloginScreen = new loginScreen();
                    myloginScreen.loginScreenPage();
                    break;
                case 1:
                    CancelReservationPage mycancelReservation = new CancelReservationPage();
                    mycancelReservation.cancelReservationPage();
                    break;
                case 2:
                    Login myLogin = new Login();
                    myLogin.LoginPage();
                    break;     
            }
        }
    }
}
