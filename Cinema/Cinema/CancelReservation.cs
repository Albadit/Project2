using Cinema.page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Cinema
{
    class CancelReservation
    {
        private int SelectedIndex;
        private string[] Options;
        private string Prompt;

        public CancelReservation(string title, string[] options)
        {
            Prompt = title;
            Options = options;
            SelectedIndex = 0;
        }

        public void CancelYourReservation()
        {

            Write("Reservation Code: ");
            var reservationcode = ReadLine();
            int ReservationCode = Convert.ToInt32(reservationcode);
            List<int> checkList = ReservationCheck.checkList;
            List<string> ReservationList = ReservationCheck.ReservationList;
            int i = 0;

            foreach (int check in checkList.ToArray())
            {
                if (ReservationCode == check)
                {
                    Write(ReservationList[i]);
                }
                i++;
            }
        }

        class Reservation
        {
            /*public int ReservationCode { get; set; } = 0;
            public string Movies { get; set; } = string.Empty;
            public string Name { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string Number { get; set; } = string.Empty;
            public int Age { get; set; } = 0;

            public static List<string> jsonList = new List<string>();

            public static string JsonFileName() => Path.Combine("data", "reservation.json");

            public static List<Reservation> ReadAll()
            {
                string json = File.ReadAllText(JsonFileName());
                return JsonSerializer.Deserialize<List<Reservation>>(json) ?? new List<Reservation>();
            }

            public static void WriteAll(List<Movie> accounts)
            {
                string json = JsonSerializer.Serialize(accounts);
                File.WriteAllText(JsonFileName(), json);
            }
            public void Reservations()
            {
                var Reservations = Reservation.ReadAll();
                foreach (var reservations in Reservations)
                {

                }
                Reservation.WriteAll(Reservations);
            }*/
        }

        private void Display()
        {
            WriteLine(Prompt);

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

                if (keyPressed == ConsoleKey.Backspace)
                {
                    chooseScreen.chooseScreenPage();
                }

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
