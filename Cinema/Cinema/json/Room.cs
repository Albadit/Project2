using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using static System.Console;
using System.Globalization;

namespace Cinema
{
    class Room
    {
        public int Id { get; set; } = 0;
        public int[][] Seats { get; set; } = Array.Empty<int[]>();

        /*public static List<int> seatList1 = new();*/
        public static int[][] seatList1 = Array.Empty<int[]>();
        public static int[][] seatList2 = Array.Empty<int[]>();

        public static string JsonFileName() => Path.Combine("data", "room.json");

        public static List<Room> ReadAll()
        {
            string json = File.ReadAllText(JsonFileName());
            return JsonSerializer.Deserialize<List<Room>>(json) ?? new List<Room>();
        }

        public static void WriteAll(List<Room> List)
        {
            string json = JsonSerializer.Serialize(List);
            File.WriteAllText(JsonFileName(), json);
        }

        public static void Products()
        {
            var seats = ReadAll();
            foreach (var seat in seats)
            {
                seatList1.Add(seat.Seats);
            } 
        }
    }
}
