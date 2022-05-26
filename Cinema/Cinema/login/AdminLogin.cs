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

            Write("How many times does the movie play a day? ");
            int start_amount = int.Parse(ReadLine());
            int[][] starting_times = new int[start_amount][];
            int[] seatid = new int[start_amount];
            int[][]seats = Array.Empty<int[]>();
            for (int i = 0; i < start_amount; i++)
            {
                Write($"What time does the movie start (HH:MM)? ({i+1}) ");
                string time_unedited = ReadLine();
                int[] time_edited = time_unedited.Split(':').Select(Int32.Parse).ToArray();
                starting_times[i] = time_edited;
                bool choice_made = false;
                while (choice_made == false) { 
                    Write("How big is the room? Choose between (Small, Medium or Large): ");
                    string room_choice = ReadLine();
                    if (room_choice.ToUpper() == "SMALL" || room_choice.ToUpper() == "S")
                    {
                        seatid[i] = 0;
                        seats = new int[][] 
                        {
                        new int[] { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 },
                        new int[] { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 },
                        new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                        new int[] { 1, 1, 1, 1, 1, 2, 2, 1, 1, 1, 1, 1 },
                        new int[] { 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1 },
                        new int[] { 1, 1, 1, 2, 2, 3, 3, 2, 2, 1, 1, 1 },
                        new int[] { 1, 1, 1, 2, 2, 3, 3, 2, 2, 1, 1, 1 },
                        new int[] { 1, 1, 1, 2, 2, 3, 3, 2, 2, 1, 1, 1 },
                        new int[] { 1, 1, 1, 2, 2, 3, 3, 2, 2, 1, 1, 1 },
                        new int[] { 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1 },
                        new int[] { 1, 1, 1, 1, 1, 2, 2, 1, 1, 1, 1, 1 },
                        new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                        new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                        new int[] { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 },
                        };
                        break;
                    }
                    else if (room_choice.ToUpper() == "MEDIUM" || room_choice.ToUpper() == "M")
                    {
                        seatid[i] = 1;
                        seats = new int[][]
                        {
                        new int[] { 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0 },
                        new int[] { 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0 },
                        new int[] { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 },
                        new int[] { 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 0, 0 },
                        new int[] { 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 0, 0 },
                        new int[] { 0, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 0 },
                        new int[] { 0, 1, 1, 1, 2, 2, 2, 2, 3, 3, 2, 2, 2, 2, 1, 1, 1, 0 },
                        new int[] { 0, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 2, 2, 2, 2, 1, 1, 0 },
                        new int[] { 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 2, 2, 2, 2, 1, 1 },
                        new int[] { 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 2, 2, 2, 2, 1, 1 },
                        new int[] { 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 2, 2, 2, 2, 1, 1 },
                        new int[] { 1, 1, 1, 2, 2, 2, 3, 3, 3, 3, 3, 3, 2, 2, 2, 1, 1, 1 },
                        new int[] { 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 2, 2, 2, 2, 1, 1, 1 },
                        new int[] { 0, 1, 1, 1, 2, 2, 2, 2, 3, 3, 2, 2, 2, 2, 1, 1, 1, 0 },
                        new int[] { 0, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 0 },
                        new int[] { 0, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 0 },
                        new int[] { 0, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 0 },
                        new int[] { 0, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 0 },
                        new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                        };
                        break;
                    }
                    else if (room_choice.ToUpper() == "LARGE" || room_choice.ToUpper() == "L")
                    {
                        seatid[i] = 2;
                        seats = new int[][]
                        {
                        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                        new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0 },
                        new int[] { 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0 },
                        new int[] { 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0 },
                        new int[] { 0, 0, 0, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 0, 0, 0 },
                        new int[] { 0, 0, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 0, 0 },
                        new int[] { 0, 0, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 0, 0 },
                        new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 0 },
                        new int[] { 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1 },
                        new int[] { 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1 },
                        new int[] { 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1 },
                        new int[] { 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1 },
                        new int[] { 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1 },
                        new int[] { 0, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 0 },
                        new int[] { 0, 0, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 0, 0 },
                        new int[] { 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 0, 0, 0 },
                        new int[] { 0, 0, 0, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 0, 0, 0 },
                        new int[] { 0, 0, 0, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 0, 0, 0 },
                        new int[] { 0, 0, 0, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 0, 0, 0 },
                        new int[] { 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0 },
                        };
                        break;
                    }
                    else
                    {
                        WriteLine("Sorry, I do not know that option. Please choose between (Small, Medium or Large): ");
                    }
                }
            }

            WriteLine("\nMovie has been successfully added.");
            Thread.Sleep(1000);
            Clear();

            Movie.MoviesAdd(name, duration, genres, age);
            for (int i = 0; i < start_amount; i++)
            {
                Time.AddTimesToJson(duration, starting_times[i], seatid[i], seats);
            }
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
