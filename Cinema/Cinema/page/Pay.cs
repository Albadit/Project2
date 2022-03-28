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
            string prompt = "Choose a payment method:\n";
            string[] options = { "Paypal", "Ideal", "Creditcard\n", "Back" };
            Menu mainMenu = new Menu(prompt, options);
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