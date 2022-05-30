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

            Write("How many days do you want to add? ");
            string? day_amount = ReadLine();
            string day_amounts = day_amount ?? string.Empty;
            int day_amountss = 0;
            if (day_amounts.All(char.IsNumber) && day_amount != string.Empty) day_amountss = Convert.ToInt32(day_amount);

            int[][] date = new int[day_amountss][];
            int[][][] starting_times = new int[day_amountss][][];
            int[][] room_array = new int[day_amountss][];

            for (int i = 0; i < day_amountss; i++)
            {
                Write($"What is the date of day {i + 1} (YYYY/MM/DD)? ");
                string? date_unedited = ReadLine();
                string date_unediteds = date_unedited ?? string.Empty;
                date[i] = date_unediteds.Split('/').Select(Int32.Parse).ToArray();
                
                Write($"How many times does the movie play on {date_unedited}? ");
                string? times_amount = ReadLine();
                string times_amounts = times_amount ?? string.Empty;
                int times_amountss = 0;
                if (times_amounts.All(char.IsNumber) && times_amount != string.Empty) times_amountss = Convert.ToInt32(times_amount);

                for (int j = 0; j < times_amountss; j++)
                {
                    starting_times[i] = new int[times_amountss][];
                    room_array[i] = new int[times_amountss];

                    Write($"How late does the movie start on {date_unedited} timestamp {j + 1} (HH:MM)? ");
                    string? time_unedited = ReadLine();
                    string time_unediteds = time_unedited ?? string.Empty;
                    starting_times[i][j] = time_unediteds.Split(':').Select(Int32.Parse).ToArray();

                    Write("How big is the room? Choose between (Small, Medium or Large): ");
                    string? room_choice = ReadLine();
                    string room_choices = room_choice ?? string.Empty;

                    bool make_choices = true;
                    while (make_choices) {
                        if (room_choices.ToUpper() == "SMALL" || room_choices.ToUpper() == "S") { room_array[i][j] = 0; make_choices = false; }
                        else if (room_choices.ToUpper() == "MEDIUM" || room_choices.ToUpper() == "M") { room_array[i][j] = 1; make_choices = false; }
                        else if (room_choices.ToUpper() == "LARGE" || room_choices.ToUpper() == "L") { room_array[i][j] = 2; make_choices = false; }
                        else 
                        {
                            if (room_choices == string.Empty) { WriteLine("\nDon't leave blank!"); }
                            else { WriteLine("Sorry, I do not know that option. Please choose between (Small, Medium or Large): "); }

                            room_choice = ReadLine();
                            room_choices = room_choice ?? string.Empty;
                        }
                    }
                    Datetime.TimesAddNew(MovieId, movies[MovieId].Duration, date[i], starting_times[i][j], room_array[i][j]);
                }
            }

            WriteLine("\nMovie plan has been successfully added.");
            Thread.Sleep(1000);
            Clear();
            Home.HomePage();
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
