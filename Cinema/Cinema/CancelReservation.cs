using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using static System.Console;

namespace Cinema
{
    class CancelReservation
    {
        public int ReservationCode { get; set; } = 0;
        public string Movies { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public int Age { get; set; } = 0;

        public static List<string> ReservationList = new List<string>();
        public static List<int> checkList = new List<int>();


        public static string JsonFileName() => Path.Combine("data", "reservation.json");

        public static List<ReservationCheck> ReadAll()
        {
            string json = File.ReadAllText(JsonFileName());
            return JsonSerializer.Deserialize<List<ReservationCheck>>(json) ?? new List<ReservationCheck>();
        }
        public static void CancelReservations()
        {
            var ReservationCheck = ReadAll();

            foreach (var check in ReservationCheck)
            {
                Write(check);
            }
        }
    }
}