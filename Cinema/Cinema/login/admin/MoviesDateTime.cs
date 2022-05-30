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
            int day_amount = int.Parse(ReadLine());
            int[][] date = new int[day_amount][];
            int[][][] starting_times = new int[day_amount][][];
            int[][] room_array = new int[day_amount][];
            for (int i = 0; i < day_amount; i++)
            {
                Write($"What is the date of day {i + 1} (YYYY/MM/DD)? ");
                string? date_unedited = ReadLine();
                date[i] = date_unedited.Split('/').Select(Int32.Parse).ToArray();

                Write($"How many times does the movie play on {date_unedited}? ");
                int times_amount = int.Parse(ReadLine());
                for (int j = 0; j < times_amount; j++)
                {
                    starting_times[i] = new int[times_amount][];
                    room_array[i] = new int[times_amount];
                    Write($"How late does the movie start on {date_unedited} timestamp {j + 1} (HH:MM)? ");
                    string? time_unedited = ReadLine();
                    starting_times[i][j] = time_unedited.Split(':').Select(Int32.Parse).ToArray();

                    bool choice_made = false;
                    while (choice_made == false)
                    {
                        Write("How big is the room? Choose between (Small, Medium or Large): ");
                        string room_choice = ReadLine();
                        if (room_choice.ToUpper() == "SMALL" || room_choice.ToUpper() == "S")
                        {
                            room_array[i][j] = 0;
                            choice_made = true;
                        }
                        else if (room_choice.ToUpper() == "MEDIUM" || room_choice.ToUpper() == "M")
                        {
                            room_array[i][j] = 1;
                            choice_made = true;
                        }
                        else if (room_choice.ToUpper() == "LARGE" || room_choice.ToUpper() == "L")
                        {
                            room_array[i][j] = 2;
                            choice_made = true;
                        }
                        else
                        {
                            WriteLine("Sorry, I do not know that option. Please choose between (Small, Medium or Large): ");
                        }
                    }
                    Datetime.TimesAddNew(MovieId, movies[MovieId].Duration, date[i], starting_times[i][j], room_array[i][j]);
                }
            }

            WriteLine("\nMovie plan has been successfully added.");
            Thread.Sleep(1000);
            Clear();

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
