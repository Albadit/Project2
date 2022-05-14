using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Cinema.page
{
    class ReservationInfos
    {
        private int SelectedIndex;
        private string Prompt;
        private int ReservationId;

        public ReservationInfos(string title, int reservationId)
        {
            Prompt = title;
            SelectedIndex = 0;
            ReservationId = reservationId;
        }

        private void Display()
        {
            WriteLine(Prompt);

            List<Reservation> Reservations = Reservation.Reservations();
            List<Movie> movies = Movie.Movies();
            List<Time> times = Time.Times();
            List<Room> rooms = Room.Rooms();
            List<string> reservationList = new();

            foreach (Reservation reservation in Reservations)
            {
                if (ReservationId == reservation.Id)
                {
                    int time0 = times[reservation.TimeId].Start[0];
                    int time1 = times[reservation.TimeId].Start[1];
                    int hour = time0 * 60;
                    double minutes = hour + time1 + times[reservation.TimeId].Duration;
                    double minute = minutes / 60;
                    hour = (int)(minutes / 60);
                    int min = (int)((minute - (int)minute) * 60);

                    string seat = string.Empty;
                    foreach (var seats in reservation.YourSeats)
                    {
                        string letter = string.Empty;
                        if (seats[0] == 1) letter = "S";
                        if (seats[0] == 2) letter = "M";
                        if (seats[0] == 3) letter = "v";
                        seat += $"{letter} seat | row: {seats[1]} | column: {seats[2]} | {rooms[1].Price[seats[0]]}\n";
                    }
                    string order = string.Empty;
                    foreach (var seats in reservation.OrdersList) order += $"{seats}\n";

                    decimal total = reservation.TotalPriceRoom + reservation.TotalPriceOrder;
                    string price = total.ToString("0.00", CultureInfo.InvariantCulture);
                    WriteLine($"ReservationCode: {reservation.ReservationCode}\nMovie: {movies[reservation.MovieId].Name}\nTime: {time0}:{time1} till {hour}:{min}\n\nSeats:\n{seat}\nOrder:\n{order}\nTotalPrice: {price}");
                }
            }
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
