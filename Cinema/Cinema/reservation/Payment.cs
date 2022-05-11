using Cinema.page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Console;
using System.IO;

namespace Cinema
{
    class Payment
    {
        private int SelectedIndex;
        private int ReservationCode;
        private readonly string[] Options;
        private readonly string Prompt;
        private readonly int MovieId;
        private readonly int[][] YourSeats;
        private readonly decimal TotalPriceRoom;
        private readonly List<string> OrdersList;
        private readonly decimal TotalPriceOrder;
        private readonly string[] Information;
        
        public Payment(string title, string[] options, int movieId, int[][] yourSeats, decimal totalPriceRoom, List<string> ordersList, decimal totalPriceOrder, string[] information)
        {
            Prompt = title;
            Options = options;
            SelectedIndex = 0;
            ReservationCode = 0;
            MovieId = movieId;
            YourSeats = yourSeats;
            TotalPriceRoom = totalPriceRoom;
            OrdersList = ordersList;
            TotalPriceOrder = totalPriceOrder;
            Information = information;
        }
        
        public void Login()
        {
            Write("Gebruikersnaam: ");
            string? username = ReadLine();
            Write("Wachtwoord: ");
            var password = string.Empty;

            ConsoleKey key;
            do
            {
                var keyInfo = ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    Write("\b \b");
                    password = password[0..^1];
                }
                else if (key == ConsoleKey.Spacebar && password.Length > 0)
                {
                    Write("");
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Write("*");
                    password += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);

            Clear();
            WriteLine(Prompt);
            WriteLine($"Thank you for your reservation {username}. Your reservation had been succesfully received.\nYou will receive a confirmation e-mail within 10 minutes.\n");

            Random generator = new();
            ReservationCode = generator.Next(100000, 999999);

            (List<Reservation> reservationId, int reservationCode) = Reservation.Reservations(ReservationCode, MovieId, YourSeats, TotalPriceRoom, OrdersList, TotalPriceOrder, Information);

            WriteLine($"Your reservationcode is: {reservationCode}\n");
        }

        private void Display()
        {
            WriteLine(Prompt);

            Login();

            for (int i = 0; i < Options.Length; i++)
            {
                string currentOptions = Options[i];

                if (SelectedIndex == i) 
                { 
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;
                }
                else 
                {
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                }

                if (i == Options.Length - 1)
                {
                    WriteLine($" {currentOptions}");
                }
                else if (i == Options.Length - 2)
                {
                    WriteLine($"{i + 1}) {currentOptions}\n");
                }
                else
                {
                    WriteLine($"{i + 1}) {currentOptions}");
                }
                
            }
            ResetColor();
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

                    if(SelectedIndex < 0)
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
