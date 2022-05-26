using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.page
{
    class AdminSelect
    {
        public static void AdminSelectPage()
        {
            string prompt = $"Welcome Please select you reservation options.\n";
            string[] options = { "Information", "Cancel", "Back" };
            Menu mainMenu = new(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    //ReservationInfo.ReservationInfoPage();
                    break;
                case 1:
                    //ReservationCancel.ReservationCancelPage();
                    break;
                case 2:
                    //Login.LoginPage();
                    break;
            }
           
        }
    }
}
