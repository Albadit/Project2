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
        public Movie(int id, string name, string[] genre, int age)
        {
            Id = id;
            Name = name;
            Genre = genre;
            Age = age;
        }

        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string[] Genre { get; set; } = Array.Empty<string>();
        public int Age { get; set; } = 0;

        public static string JsonFileName() => Path.Combine("reservation/data", "movies.json");

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
                movieId.AddRange(new List<Movie> { new Movie(movie.Id, movie.Name, movie.Genre, movie.Age) });
            }
            return movieId;
        }
    }
}
