
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.page
{
    class RegistrationPage
    {
        public static void RegistrationPagePage(string filmName)
        {
            string title = "Fill in your info.\n";
            string[] options = { "Payment", "Back" };
            Registration mainMenu = new(title, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Pay.PayPage(filmName);
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    Seats.SeatPage(filmName);
                    break;
            }
        }
    }
}