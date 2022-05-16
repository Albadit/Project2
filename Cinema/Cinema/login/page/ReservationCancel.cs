using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.page
{
    class ReservationCancel
    {
        public static void ReservationCancelPage(int reservationId)
        {
            string prompt = "Thank you for canceling. but, too bad you canceled this movie.\n";
            ReservationCancels mainMenu = new(prompt, reservationId);
            int selectedIndex = mainMenu.Run();

            Home.HomePage();
        }
    }
}
