using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.page
{
    class CancelReservationPage
    {
        public void cancelReservationPage()
        {
            List<string> ReservationList = ReservationCheck.ReservationList;
            string title = "Please put in your reservation code you would like to cancel.\n";
            string[] options = ReservationList.ToArray();
            CancelReservation mainMenu = new CancelReservation(title, options);
            int selectedIndex = mainMenu.Run();

            if (selectedIndex == options.Length - 1)
            {
                chooseScreen mychooseScreen = new chooseScreen();
                mychooseScreen.chooseScreenPage();
            }

        }
    }
}
