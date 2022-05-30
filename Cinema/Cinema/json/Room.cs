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
        public Room(int id, decimal[] price, int[][] seats)
        {
            Id = id;
            Price = price;
            Seats = seats;
        }

        public int Id { get; set; } = 0;
        public decimal[] Price { get; set; } = Array.Empty<decimal>();
        public int[][] Seats { get; set; } = Array.Empty<int[]>();

        public static string JsonFileName() => Path.Combine("data", "room.json");

        public static List<Room> ReadAll()
        {
            string json = File.ReadAllText(JsonFileName());
            return JsonSerializer.Deserialize<List<Room>>(json) ?? new List<Room>();
        }

        public static void WriteAll(List<Room> rooms)
        {
            string json = JsonSerializer.Serialize(rooms);
            File.WriteAllText(JsonFileName(), json);
        }

        public static List<Room> Rooms()
        {
            List<Room> roomId = new();

            var rooms = ReadAll();
            foreach (var room in rooms)
            {
                roomId.AddRange(new List<Room> { new Room(room.Id, room.Price, room.Seats) });
            }
            return roomId;
        }
    }
}
