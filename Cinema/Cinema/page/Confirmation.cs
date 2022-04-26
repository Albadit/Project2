using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.page
{
    class Confirmation
    {
        public static void ConfirmationPage(string filmName)
        {
            string title = "Thank you for your reservation. Your reservation had been succesfully received. " +
            "You will receive a confirmation e-mail within 10 minutes.\n";
            string[] options = {"Back"};
            Menu mainMenu = new(title, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    idealLogin.idealLoginPage(filmName);
                    break;
            }
        }
    }
}
