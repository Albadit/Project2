using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Cinema.page
{
    class ReservationCancels
    {
        private int SelectedIndex;
        private string Prompt;
        private int ReservationId;
        List<Reservation> Reservations = Reservation.Reservations();

        public ReservationCancels(string title, int reservationId)
        {
            Prompt = title;
            SelectedIndex = 0;
            ReservationId = reservationId;
        }

        private void Display()
        {
            WriteLine(Prompt);
            Time.TimesChange(Reservations[ReservationId].TimeId, Reservations[ReservationId].YourSeats);
            Reservation.ReservationsCancel(Reservations, ReservationId);
            WriteLine("\nPress enter to go back.");
        }

        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Clear();
                Display();

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;
            }
            while (keyPressed != ConsoleKey.Enter);

            return SelectedIndex;
        }
    }
}
