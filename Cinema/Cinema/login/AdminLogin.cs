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
            //Login Attempts counter
            string username = string.Empty;
            string password = string.Empty;
            //Simple iteration upto three times
            WriteLine(Prompt);
            Write("Enter username: ");
            username = ReadLine();
            Write("Enter password: ");
            password = ReadLine();

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

        public void RegisterMovie()
        {
            Write("What is the title of the movie? ");
            string name = ReadLine();
            Write("What is the duration of the movie in minutes? ");
            int duration = int.Parse(ReadLine());
            Write("How many genres does the movie have? ");
            int genre_amount = int.Parse(ReadLine());
            string[] genres = Array.Empty<string>();
            for (int i = 0; i < genre_amount; i++)
            {
                Write("What is one of the genres? ");
                string genre = ReadLine();
                genres = genres.Concat(new string[] { genre }).ToArray();
            }
            Write("What is the minimum age to see the movie? ");
            int age = int.Parse(ReadLine());

            WriteLine("\nMovie has been successfully added.");
            Thread.Sleep(1000);
            Clear();

            Movie.MoviesAdd(name, duration, genres, age);
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
