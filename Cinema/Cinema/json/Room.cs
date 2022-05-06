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
        public decimal[] Price { get; set; } = Array.Empty<decimal>();
        public int[][] Seats { get; set; } = Array.Empty<int[]>();
        
        public static string JsonFileName() => Path.Combine("data", "room.json");

        public static List<Room> ReadAll()
        {
            string json = File.ReadAllText(JsonFileName());
            return JsonSerializer.Deserialize<List<Room>>(json) ?? new List<Room>();
        }

        public static (List<List<List<int>>>, List<decimal>) Rooms()
        {
            List<decimal> seatPrice = new();
            List<List<List<int>>> seatList = new();

            var rooms = ReadAll();
            foreach (var seats in rooms)
            {
                foreach (var price in seats.Price)
                {
                    seatPrice.Add(price);
                }

                List<List<int>> seatList2 = new();
                foreach (var seat in seats.Seats)
                {
                    List<int> temp = new(seat);
                    seatList2.Add(temp);
                }
                seatList.Add(seatList2);
            }
            return (seatList, seatPrice);
        }
    }
}
