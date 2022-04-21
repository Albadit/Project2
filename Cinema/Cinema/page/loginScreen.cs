using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.page
{
    class loginScreen
    {
        public void loginScreenPage()
        {
            List<string> ReservationList = ReservationCheck.ReservationList;

/*            ReservationCheck myReservationCheck = new ReservationCheck();
            myReservationCheck.Reservations();
            ReservationList.Add("Back");*/

            string title = "Please put in your reservation code.\n";
            string[] options = ReservationList.ToArray();
            ReservationCodeCheck mainMenu = new ReservationCodeCheck(title, options);
            int selectedIndex = mainMenu.Run();

            if (selectedIndex == options.Length - 1)
            {
                chooseScreen mychooseScreen = new chooseScreen();
                mychooseScreen.chooseScreenPage();
            }

            /*switch (selectedIndex)
            {
                case 0:
                    chooseScreen mychooseScreen = new chooseScreen();
                    mychooseScreen.chooseScreenPage();
                    break;
            }*/
        }
    }
}
