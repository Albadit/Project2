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
        public Reservation(int reservationId, int reservationCode, int movieId, int[][] yourSeats, decimal totalPriceRoom, List<string> ordersList, decimal totalPriceOrder, string[] information)
        {
            ReservationId = reservationId;
            ReservationCode = reservationCode;
            MovieId = movieId;
            MovieId = movieId;
            YourSeats = yourSeats;
            TotalPriceRoom = totalPriceRoom;
            OrdersList = ordersList;
            TotalPriceOrder = totalPriceOrder;
            Information = information;
        }

        public int ReservationId { get; set; } = 0;
        public int ReservationCode { get; set; } = 0;
        public int MovieId { get; set; } = 0;
        public int[][] YourSeats { get; set; } = Array.Empty<int[]>();
        public decimal TotalPriceRoom { get; set; } = 0;
        public List<string> OrdersList { get; set; } = new();
        public decimal TotalPriceOrder { get; set; } = 0;
        public string[] Information { get; set; } = Array.Empty<string>();

        public static string JsonFileName() => Path.Combine("reservation/data", "reservation.json");

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

        public static (List<Reservation>, int reservationCode) Reservations(int reservationCode, int movieId, int[][] yourSeats, decimal totalPriceRoom, List<string> ordersList, decimal totalPriceOrder, string[] information)
        {
            List<Reservation> reservationsId = new();
            int id = 0;
            Random generator = new();

            var reservation = ReadAll();
            foreach (var book in reservation)
            {
                id++;
                if (reservationCode == book.ReservationCode) { reservationCode = generator.Next(100000, 999999); }
                reservationsId.AddRange(new List<Reservation> { new Reservation(book.ReservationId, book.ReservationCode, book.MovieId, book.YourSeats, book.TotalPriceRoom, book.OrdersList, book.TotalPriceOrder, book.Information) });
            }
            reservationsId.AddRange(new List<Reservation> { new Reservation(id , reservationCode, movieId, yourSeats, totalPriceRoom, ordersList, totalPriceOrder, information) });
            WriteAll(reservationsId);
            return (reservationsId, reservationCode);
        }
    }
}
