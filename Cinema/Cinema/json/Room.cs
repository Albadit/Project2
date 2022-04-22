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

        public static List<List<List<int>>> seatList = new();
        public static List<List<int>> seatList2 = new();
        public static List<int> seatList1 = new();
        
        public static string JsonFileName() => Path.Combine("data", "room.json");

        public static List<Room> ReadAll()
        {
            string json = File.ReadAllText(JsonFileName());
            return JsonSerializer.Deserialize<List<Room>>(json) ?? new List<Room>();
        }

        public static void Rooms()
        {
            var rooms = ReadAll();
            foreach (var seats in rooms)
            {
                foreach (var seat in seats.Seats)
                {
                    seatList1.Clear();
                    seatList1.AddRange(seat);
                    seatList2.Add(seatList1);
                }
                seatList.Add(seatList2);
                seatList2.Clear();
            }
        }
    }
}
