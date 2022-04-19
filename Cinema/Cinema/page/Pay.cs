using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.page
{
    class Pay
    {
        public void PayPage(string filmName)
        {
            string title = "Choose a payment method:\n";
            string[] options = { "Paypal", "Ideal", "CreditcardW", "Back" };
            Menu mainMenu = new Menu(title, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
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
