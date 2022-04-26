using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.page
{
    class loginScreen
    {
        public static void loginScreenPage()
        {
            List<string> ReservationList = ReservationCheck.ReservationList;

            string title = "Please put in your reservation code.\n";
            string[] options = ReservationList.ToArray();
            ReservationCodeCheck mainMenu = new(title, options);
            int selectedIndex = mainMenu.Run();

            if (selectedIndex == options.Length - 1)
            {
                chooseScreen.chooseScreenPage();
            }

        }
    }
}
