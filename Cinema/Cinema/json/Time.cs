using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using static System.Console;

namespace Cinema
{
    class Time
    {
        public Time(int id, int movieId, int duration, int[] start, int seatId, int[][] seats)
        {
            Id = id;
            MovieId = movieId;
            Duration = duration;
            Start = start;
            SeatId = seatId;
            Seats = seats;
        }

        public int Id { get; set; } = 0;
        public int MovieId { get; set; } = 0;
        public int Duration { get; set; } = 0;
        public int[] Start { get; set; } = Array.Empty<int>();
        public int SeatId { get; set; } = 0;
        public int[][] Seats { get; set; } = Array.Empty<int[]>();

        public static string JsonFileName() => Path.Combine("data", "time.json");

        public static List<Time> ReadAll()
        {
            string json = File.ReadAllText(JsonFileName());
            return JsonSerializer.Deserialize<List<Time>>(json) ?? new List<Time>();
        }

        public static void WriteAll(List<Time> Times)
        {
            string json = JsonSerializer.Serialize(Times);
            File.WriteAllText(JsonFileName(), json);
        }

        public static List<Time> Times()
        {
            List<Time> TimeId = new();

            var Times = ReadAll();
            foreach (var Time in Times)
            {
                TimeId.AddRange(new List<Time> { new Time(Time.Id, Time.MovieId, Time.Duration, Time.Start, Time.SeatId, Time.Seats) });
            }
            return TimeId;
        }

        public static List<Time> TimesAdd(int timeId, int[][] YourSeats)
        {
            List<Time> TimeId = new();

            var Times = ReadAll();
            foreach (var Time in Times)
            {
                TimeId.AddRange(new List<Time> { new Time(Time.Id, Time.MovieId, Time.Duration, Time.Start, Time.SeatId, Time.Seats) });
            }

            for (int i = 0; i < YourSeats[0].Length; i++)
            {
                TimeId[timeId].Seats[YourSeats[i][1]][YourSeats[i][2]] = 4;
            }
            
            WriteAll(TimeId);

            string sourceFile = Path.Combine("data", "time.json");
            string destinationFile = Path.Combine("../../../data", "time.json");
            try { File.Copy(sourceFile, destinationFile, true); }
            catch (IOException iox) { WriteLine(iox.Message); }

            return TimeId;
        }

        public static List<Time> TimesChange(int timeId, int[][] YourSeats)
        {
            List<Time> TimeId = new();

            var Times = ReadAll();
            foreach (var Time in Times)
            {
                TimeId.AddRange(new List<Time> { new Time(Time.Id, Time.MovieId, Time.Duration, Time.Start, Time.SeatId, Time.Seats) });
            }

            for (int i = 0; i < YourSeats[0].Length; i++)
            {
                TimeId[timeId].Seats[YourSeats[i][1]][YourSeats[i][2]] = YourSeats[i][0];
            }

            WriteAll(TimeId);

            string sourceFile = Path.Combine("data", "time.json");
            string destinationFile = Path.Combine("../../../data", "time.json");
            try { File.Copy(sourceFile, destinationFile, true); }
            catch (IOException iox) { WriteLine(iox.Message); }

            return TimeId;
        }
    }
}
