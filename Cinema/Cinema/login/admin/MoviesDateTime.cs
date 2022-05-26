using Cinema.page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Cinema
{
    class MoviesDateTime
    {
        private int MovieId;

        public MoviesDateTime(int movieId)
        {
            MovieId = movieId;
        }

        private void Display()
        {
            List<Movie> movies = Movie.Movies();

            /*Write("Day of the film: ");
            string? day = ReadLine();

            Write("Time: ");
            string? time = ReadLine();

            Write("Which room Small, Medium or Large");
            string? room = ReadLine();

            WriteLine("\nMovie plan has been successfully added.");
            Thread.Sleep(1000);
            Clear();*/

            int[] date = new int[] { 2022, 5, 28 };
            int[] start = new int[] { 12, 30 };
            int zaal = 1; // medium zaal 
            Datetime.TimesAddNew(MovieId, movies[MovieId].Duration, date, start, zaal);
        }

        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Clear();
                Display();

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;
            }
            while (keyPressed != ConsoleKey.Enter);
            return 0;
        }
    }
}
