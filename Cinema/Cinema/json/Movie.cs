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
        public string[] Genre { get; set; } = Array.Empty<string>();
        public int Age { get; set; } = 0;

        public static List<string> filmNames = new();

        public static string JsonFileName() => Path.Combine("data", "movies.json");

        public static List<Movie> ReadAll()
        {
            string json = File.ReadAllText(JsonFileName());
            return JsonSerializer.Deserialize<List<Movie>>(json) ?? new List<Movie>();
        }

        public static List<string> Movies()
        {
            List<string> movieList = new();

            var movies = ReadAll();
            foreach (var movie in movies)
            {
                string genreList = string.Empty;
                List<string> genreLists = new();
                foreach (var genre in movie.Genre)
                {
                    if (genreLists.Count == movie.Genre.Length - 1)
                    {
                        genreLists.Add(genre);
                        genreList += genre;
                    }
                    else
                    {
                        genreLists.Add(genre);
                        genreList += genre + ", ";
                    }
                }
                filmNames.Add(movie.Name);
                movieList.Add($"{movie.Name} | Genre: {genreList} | Age: {movie.Age}");
            }
            return movieList;
        }
    }
}
