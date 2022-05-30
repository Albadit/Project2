using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.page
{
    class ReservationSelect
    {
        public static void ReservationSelectPage(int reservationId)
        {
            List<Reservation> Reservations = Reservation.Reservations();

            string prompt = $"Welcome {Reservations[reservationId].PersonalInfo[0]}. Please select you reservation options.\n";
            string[] options = { "Information", "Cancel", "Back" };
            Menu mainMenu = new(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    ReservationInfo.ReservationInfoPage(reservationId);
                    break;
                case 1:
                    ReservationCancel.ReservationCancelPage(reservationId);
                    break;
                case 2:
                    Login.LoginPage();
                    break;
            }
           
        }
    }
}
