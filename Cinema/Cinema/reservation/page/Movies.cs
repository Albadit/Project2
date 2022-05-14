using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using static System.Console;

namespace Cinema.page
{
    class Movies
    {
        public static void MoviesPage()
        {
            List<Movie> movies = Movie.Movies();
            List<string> movieList = new();

            foreach (var movie in movies)
            {
                string genreList = string.Empty;
                foreach (var genre in movie.Genre)
                {
                    if (genre == movie.Genre[^1]) genreList += genre;
                    else genreList += genre + ", ";
                }
                movieList.Add($"{movie.Name} | Duration: {movie.Duration} | Genre: {genreList} | Age: {movie.Age}");
            }
            movieList.Add("Back");

            string title = "Choice your movie.\n";
            string[] options = movieList.ToArray();
            Menu mainMenu = new(title, options);
            int selectedIndex = mainMenu.Run();

            if (selectedIndex == options.Length - 1) Home.HomePage();
            else Times.TimesPage(movies[selectedIndex].Id);
        }
    }
}
