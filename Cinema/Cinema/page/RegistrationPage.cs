using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.page
{
    class RegistrationPage
    {
        public void RegistrationPagePage(string filmName)
        {
            string title = "Fill in your info.\n";
            string[] options = { "Payment", "Back" };
            Reservation mainMenu = new Reservation(title, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Pay myPay = new Pay();
                    myPay.PayPage(filmName);
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    Seats mySeating = new Seats();
                    mySeating.SeatingPage(filmName);
                    break;
            }
        }
    }
}