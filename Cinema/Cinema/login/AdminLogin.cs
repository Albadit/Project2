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
        private string[] Options;
        private string Prompt;

        public AdminLogin(string title)
        {
            Prompt = title;
            SelectedIndex = 0;
        }

        public void Login()
        {
            //Login Attempts counter
            int loginAttempts = 0;

            //Simple iteration upto three times
            for (int i = 0; i < 3; i++)
            {
                Write("Enter username: ");
                string username = ReadLine();
                Write("Enter password: ");
                string password = ReadLine();

                if (username != "valid" || password != "valid")
                {
                    loginAttempts++;
                    Clear();
                    WriteLine($"Username or password is incorrect, please try again. You have {3-loginAttempts} attempts left.\n");
                }
                else
                    break;
            }

            //Display the result
            if (loginAttempts > 2)
                WriteLine("You have tried to many times. You have been blocked out of the system.");
            else
                Clear();
                WriteLine("Login successful");
                RegisterMovie();

            ReadKey();
        }

        public void RegisterMovie()
        {
                Write("What is the title of the movie? ");
                string title = ReadLine();
                Write("What is the duration of the movie in minutes? ");
                int duration = int.Parse(ReadLine());
                Write("How many genres does the movie have? ");
                int genre_amount = int.Parse(ReadLine());
                string[] genres = new string[genre_amount];
                for (int i = 0; i < genres.Length; i++)
                {
                    Write("What is one of the genres? ");
                    genres[i] = Console.ReadLine();
                }
                Write("What is the minimum age to see the movie? ");
                int age = int.Parse(ReadLine());
                Movie.AddMovieToJson(title, duration, genres, age);
        }

        private void Display()
        {
            WriteLine(Prompt);
            Login();
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

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;

                    if (SelectedIndex < 0)
                    {
                        SelectedIndex = Options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;

                    if (SelectedIndex > Options.Length - 1)
                    {
                        SelectedIndex = 0;
                    }
                }
            }
            while (keyPressed != ConsoleKey.Enter);

            return SelectedIndex;
        }
    }
}
