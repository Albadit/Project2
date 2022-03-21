﻿using System;
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
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int Age { get; set; } = 0;

        public static string JsonFileName() => Path.Combine("data", "accounts.json");

        public static List<Movie> ReadAll()
        {
            string json = File.ReadAllText(JsonFileName());
            return JsonSerializer.Deserialize<List<Movie>>(json) ?? new List<Movie>();
        }

        public static void WriteAll(List<Movie> accounts)
        {
            string json = JsonSerializer.Serialize(accounts);
            File.WriteAllText(JsonFileName(), json);
        }
        public void Movies()
        {
            var movies = Movie.ReadAll();
            foreach (var movie in movies)
            {
                WriteLine($"{movie.Id} {movie.Name}\n");
                /*movie.Password = $"reset-{movie.Id}";*/
            }
            Movie.WriteAll(movies);
        }
    }
}
