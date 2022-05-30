using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using static System.Console;

namespace Cinema
{
    class Movie
    {
        public Movie(int id, string name, int duration, string[] genre, int age)
        {
            Id = id;
            Name = name;
            Duration = duration;
            Genre = genre;
            Age = age;
        }

        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public int Duration { get; set; } = 0;
        public string[] Genre { get; set; } = Array.Empty<string>();
        public int Age { get; set; } = 0;

        public static string JsonFileName() => Path.Combine("data", "movies.json");

        public static List<Movie> ReadAll()
        {
            string json = File.ReadAllText(JsonFileName());
            return JsonSerializer.Deserialize<List<Movie>>(json) ?? new List<Movie>();
        }

        public static void WriteAll(List<Movie> movies)
        {
            string json = JsonSerializer.Serialize(movies);
            File.WriteAllText(JsonFileName(), json);
        }

        public static List<Movie> Movies()
        {
            List<Movie> movieId = new();

            var movies = ReadAll();
            foreach (var movie in movies)
            {
                movieId.AddRange(new List<Movie> { new Movie(movie.Id, movie.Name, movie.Duration, movie.Genre, movie.Age) });
            }
            return movieId;
        }

        public static List<Movie> MoviesAdd(string name, int duration, string[] genre, int age)
        {
            List<Movie> movieId = new();
            int id = 0;

            var movies = ReadAll();
            foreach (var movie in movies)
            {
                id = movie.Id + 1;
                movieId.AddRange(new List<Movie> { new Movie(movie.Id, movie.Name, movie.Duration, movie.Genre, movie.Age) });
            }

            movieId.AddRange(new List<Movie> { new Movie(id, name, duration, genre, age) });
            WriteAll(movieId);

            string sourceFile = Path.Combine("data", "movies.json");
            string destinationFile = Path.Combine("../../../data", "movies.json");
            try { File.Copy(sourceFile, destinationFile, true); }
            catch (IOException iox) { WriteLine(iox.Message); }
            return movieId;
        }
    }
}
