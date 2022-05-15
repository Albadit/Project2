using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.page
{
    class ReservationInfo
    {
        public static void ReservationInfoPage(int reservationId)
        {
            string prompt = $"Here is your information.\n";
            string[] options = { "Back" };
            ReservationInfos mainMenu = new(prompt, reservationId);
            int selectedIndex = mainMenu.Run();

            if (selectedIndex == options.Length - 1) ReservationSelect.ReservationSelectPage(reservationId);

        }
    }
}
