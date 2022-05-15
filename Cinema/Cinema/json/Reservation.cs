using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using static System.Console;

namespace Cinema
{
    class Reservation
    {
        public Reservation(int id, int reservationCode, int movieId, int timeId, int[][] yourSeats, decimal totalPriceRoom, List<string> ordersList, decimal totalPriceOrder, string[] personalInfo)
        {
            Id = id;
            ReservationCode = reservationCode;
            MovieId = movieId;
            TimeId = timeId;
            YourSeats = yourSeats;
            TotalPriceRoom = totalPriceRoom;
            OrdersList = ordersList;
            TotalPriceOrder = totalPriceOrder;
            PersonalInfo = personalInfo;
        }

        public int Id { get; set; } = 0;
        public int ReservationCode { get; set; } = 0;
        public int MovieId { get; set; } = 0;
        public int TimeId { get; set; } = 0;
        public int[][] YourSeats { get; set; } = Array.Empty<int[]>();
        public decimal TotalPriceRoom { get; set; } = 0;
        public List<string> OrdersList { get; set; } = new();
        public decimal TotalPriceOrder { get; set; } = 0;
        public string[] PersonalInfo { get; set; } = Array.Empty<string>();

        public static string JsonFileName() => Path.Combine("data", "reservation.json");

        public static List<Reservation> ReadAll()
        {
            string json = File.ReadAllText(JsonFileName());
            return JsonSerializer.Deserialize<List<Reservation>>(json) ?? new List<Reservation>();
        }

        public static void WriteAll(List<Reservation> reservation)
        {
            string json = JsonSerializer.Serialize(reservation);
            File.WriteAllText(JsonFileName(), json);
        }

        public static List<Reservation> Reservations()
        {
            List<Reservation> reservationsId = new();
            var reservation = ReadAll();
            foreach (var book in reservation)
            {
                reservationsId.AddRange(new List<Reservation> { new Reservation(book.Id, book.ReservationCode, book.MovieId, book.TimeId, book.YourSeats, book.TotalPriceRoom, book.OrdersList, book.TotalPriceOrder, book.PersonalInfo) });
            }
            return reservationsId;
        }

        public static int ReservationsAdd(int reservationCode, int movieId, int timeId, int[][] yourSeats, decimal totalPriceRoom, List<string> ordersList, decimal totalPriceOrder, string[] personalInfo)
        {
            List<Reservation> reservationsId = new();
            Random generator = new();
            bool check = true;
            int id = 0;

            var reservation = ReadAll();
            foreach (var book in reservation)
            {
                id = book.Id + 1;
                if (reservationCode == book.ReservationCode) {  }
                reservationsId.AddRange(new List<Reservation> { new Reservation(book.Id, book.ReservationCode, book.MovieId, book.TimeId, book.YourSeats, book.TotalPriceRoom, book.OrdersList, book.TotalPriceOrder, book.PersonalInfo) });
            }

            while(check)
            {
                for (int i = 0; i < reservationsId.Count; i++)
                {
                    if (reservationsId[i].ReservationCode != reservationCode)
                    {
                        reservationCode = generator.Next(100000, 999999);
                        check = false;
                    }
                    else check = true;
                }
            }

            reservationsId.AddRange(new List<Reservation> { new Reservation(id, reservationCode, movieId, timeId, yourSeats, totalPriceRoom, ordersList, totalPriceOrder, personalInfo) });
            WriteAll(reservationsId);

            string sourceFile = Path.Combine("data", "reservation.json");
            string destinationFile = Path.Combine("../../../data", "reservation.json");
            try { File.Copy(sourceFile, destinationFile, true); }
            catch (IOException iox) { WriteLine(iox.Message); }

            return reservationCode;
        }

        public static void ReservationsCancel(List<Reservation> Reservations, int reservationId)
        {
            for (int i = 0; i < Reservations.Count; i++)
            {
                if (Reservations[i].Id == reservationId)
                {
                    Reservations.Remove(Reservations[i]);
                }
            }
            WriteAll(Reservations);

            string sourceFile = Path.Combine("data", "reservation.json");
            string destinationFile = Path.Combine("../../../data", "reservation.json");
            try { File.Copy(sourceFile, destinationFile, true); }
            catch (IOException iox) { WriteLine(iox.Message); }
        }
    }
}
