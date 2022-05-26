using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using static System.Console;

namespace Cinema
{
    class Datetime
    {
        public Datetime(int id, int movieId, int duration, int[] date, int[] start, int seatId, int[][] seats)
        {
            Id = id;
            MovieId = movieId;
            Duration = duration;
            Date = date;
            Start = start;
            SeatId = seatId;
            Seats = seats;
        }

        public int Id { get; set; } = 0;
        public int MovieId { get; set; } = 0;
        public int Duration { get; set; } = 0;
        public int[] Date { get; set; } = Array.Empty<int>();
        public int[] Start { get; set; } = Array.Empty<int>();
        public int SeatId { get; set; } = 0;
        public int[][] Seats { get; set; } = Array.Empty<int[]>();

        public static string JsonFileName() => Path.Combine("data", "datetime.json");

        public static List<Datetime> ReadAll()
        {
            string json = File.ReadAllText(JsonFileName());
            return JsonSerializer.Deserialize<List<Datetime>>(json) ?? new List<Datetime>();
        }

        public static void WriteAll(List<Datetime> Times)
        {
            string json = JsonSerializer.Serialize(Times);
            File.WriteAllText(JsonFileName(), json);
        }

        public static List<Datetime> Times()
        {
            List<Datetime> TimeId = new();

            var Times = ReadAll();
            foreach (var Time in Times)
            {
                TimeId.AddRange(new List<Datetime> { new Datetime(Time.Id, Time.MovieId, Time.Duration, Time.Date, Time.Start, Time.SeatId, Time.Seats) });
            }
            return TimeId;
        }

        public static List<Datetime> TimesAdd(int timeId, int[][] YourSeats)
        {
            List<Datetime> TimeId = new();

            var Times = ReadAll();
            foreach (var Time in Times)
            {
                TimeId.AddRange(new List<Datetime> { new Datetime(Time.Id, Time.MovieId, Time.Duration, Time.Date, Time.Start, Time.SeatId, Time.Seats) });
            }

            for (int i = 0; i < YourSeats.Length; i++)
            {
                TimeId[timeId].Seats[YourSeats[i][1]][YourSeats[i][2]] = 4;
            }
            
            WriteAll(TimeId);

            string sourceFile = Path.Combine("data", "datetime.json");
            string destinationFile = Path.Combine("../../../data", "datetime.json");
            try { File.Copy(sourceFile, destinationFile, true); }
            catch (IOException iox) { WriteLine(iox.Message); }

            return TimeId;
        }

        public static List<Datetime> TimesChange(int timeId, int[][] yourSeats)
        {
            List<Datetime> TimeId = new();

            var Times = ReadAll();
            foreach (var Time in Times)
            {
                TimeId.AddRange(new List<Datetime> { new Datetime(Time.Id, Time.MovieId, Time.Duration, Time.Date, Time.Start, Time.SeatId, Time.Seats) });
            }

            for (int i = 0; i < yourSeats.Length; i++)
            {
                TimeId[timeId].Seats[yourSeats[i][1]][yourSeats[i][2]] = yourSeats[i][0];
            }

            WriteAll(TimeId);

            string sourceFile = Path.Combine("data", "datetime.json");
            string destinationFile = Path.Combine("../../../data", "datetime.json");
            try { File.Copy(sourceFile, destinationFile, true); }
            catch (IOException iox) { WriteLine(iox.Message); }

            return TimeId;
        }
    }
}
