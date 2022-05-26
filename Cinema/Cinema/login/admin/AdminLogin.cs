using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Cinema.page
{
    class AdminLogin
    {
        private int SelectedIndex;
        private string Prompt;

        public AdminLogin(string title)
        {
            Prompt = title;
            SelectedIndex = 0;
        }

        public void Login()
        {
            //Simple iteration upto three times
            WriteLine(Prompt);
            Write("Enter username: ");
            string? username = ReadLine();
            Write("Enter password: ");
            string? password = ReadLine();

            while (username != "admin" && password != "admin")
            {
                WriteLine("\nUsername or password is incorrect, please try again.\n");
                Thread.Sleep(1000);
                Clear();
                WriteLine(Prompt);
                Write("Enter username: ");
                username = ReadLine();
                Write("Enter password: ");
                password = ReadLine();
            }

            WriteLine("\nLogin successful");
            Thread.Sleep(1000);
            Clear();
        }

        public static void RegisterMovie()
        {
            Write("What is the title of the movie? ");
            string? name = ReadLine();
            string names = name ?? string.Empty;

            Write("What is the duration of the movie in minutes? ");
            string? duration = ReadLine();
            string durations = duration ?? string.Empty;
            int durationss = 0;
            if (durations.All(char.IsNumber) && duration != string.Empty) durationss = Convert.ToInt32(duration);

            while (duration == string.Empty || !durations.All(char.IsNumber))
            {
                if (duration == string.Empty) WriteLine("\nDon't leave blank!");
                else if (durationss <= 0) WriteLine($"\n{duration} is not a valid duration!");
                Thread.Sleep(1000);
                Clear();
                WriteLine($"What is the title of the movie? {name}");
                WriteLine($"What is the duration of the movie in minutes? ");
                duration = ReadLine();
                durations = duration ?? string.Empty;
            }

            Write("How many genres does the movie have? ");
            string? genre_amount = ReadLine();
            string genre_amounts = genre_amount ?? string.Empty;
            int genre_amountss = 0;
            if (genre_amounts.All(char.IsNumber) && genre_amount != string.Empty) genre_amountss = Convert.ToInt32(genre_amount);

            string[] genres = Array.Empty<string>();
            for (int i = 0; i < genre_amountss; i++)
            {
                Write("What is one of the genres? ");
                string? genre = ReadLine();
                string genress = genre ?? string.Empty;
                genres = genres.Concat(new string[] { genress }).ToArray();
            }

            Write("What is the minimum age to see the movie? ");
            string? age = ReadLine();
            string ages = age ?? string.Empty;
            int agess = 0;
            if (ages.All(char.IsNumber) && age != string.Empty) agess = Convert.ToInt32(age);

            while (age == string.Empty || !ages.All(char.IsNumber))
            {
                if (age == string.Empty) WriteLine("\nDon't leave blank!");
                else if (agess < 0) WriteLine($"\n{age} is not a valid age!");
                WriteLine($"What is the title of the movie? {name}");
                WriteLine($"What is the duration of the movie in minutes? {duration}");
                foreach (string genre in genres) { WriteLine($"What is one of the genres? {genre}"); }
                WriteLine("What is the minimum age to see the movie? ");
                age = ReadLine();
                ages = age ?? string.Empty;
            }

            WriteLine("\nMovie has been successfully added.");
            Thread.Sleep(1000);
            Clear();

            Movie.MoviesAdd(names, durationss, genres, agess);
            Home.HomePage();
        }

        private void Display()
        {
            Login();
            RegisterMovie();
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

            return SelectedIndex;
        }
    }
}
