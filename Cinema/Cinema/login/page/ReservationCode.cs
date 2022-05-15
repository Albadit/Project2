using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.page
{
    class ReservationCode
    {
        public static void ReservationCodePage()
        {
            string prompt = "Type your reservationcode.\n";
            ReservationCodes mainMenu = new(prompt);
            int reservationId = mainMenu.Run();
        }
    }
}
