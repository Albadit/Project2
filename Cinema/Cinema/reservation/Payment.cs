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
<<<<<<<< HEAD:Cinema/Cinema/reservation/PaymentLogin.cs
    class Paymentlogin
    {
        private int SelectedIndex;
        private readonly string[] Options;
        private readonly string Prompt;
        /*private readonly string Name;
        private readonly string Email;
        private readonly string Number;
        private readonly string Age;*/

        public int ReservationCode { get; set; } = 0;
        public string MovieName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string Age { get; set; } = string.Empty;

        public Paymentlogin(string title, string[] options, string name, string email, string number, string age)
========
    class Payment
    {
        private int SelectedIndex;
        private int ReservationCode;
        private readonly string[] Options;
        private readonly string Prompt;
        private readonly int MovieId;
        private readonly int TimeId;
        private readonly int[][] YourSeats;
        private readonly decimal TotalPriceRoom;
        private readonly List<string> OrdersList;
        private readonly decimal TotalPriceOrder;
        private readonly string[] PersonalInfo;
        
        public Payment(string title, string[] options, int movieId, int timeId, int[][] yourSeats, decimal totalPriceRoom, List<string> ordersList, decimal totalPriceOrder, string[] Personalinfo)
>>>>>>>> main:Cinema/Cinema/reservation/Payment.cs
        {
            Prompt = title;
            Options = options;
            SelectedIndex = 0;
            ReservationCode = 0;
<<<<<<<< HEAD:Cinema/Cinema/reservation/PaymentLogin.cs
            Name = name;
            Email = email;
            Number = number;
            Age = age;
        }

        public static string JsonFileName() => Path.Combine("reservation/data", "reservation.json");

        public static List<Example> ReadAll()
        {
            string json = File.ReadAllText(JsonFileName());
            return JsonSerializer.Deserialize<List<Example>>(json) ?? new List<Example>();
        }

        public static void WriteAll(List<Example> accounts)
        {
            string json = JsonSerializer.Serialize(accounts);
            File.WriteAllText(JsonFileName(), json);
        }

        public static void Reservation()
        {
            var accounts = ReadAll();
            /*foreach (var account in accounts)
            {
                WriteLine($"{account.Id} {account.Email}");
            }*/
            WriteAll(accounts);
        }

========
            MovieId = movieId;
            TimeId = timeId;
            YourSeats = yourSeats;
            TotalPriceRoom = totalPriceRoom;
            OrdersList = ordersList;
            TotalPriceOrder = totalPriceOrder;
            PersonalInfo = Personalinfo;
        }
        
>>>>>>>> main:Cinema/Cinema/reservation/Payment.cs
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
<<<<<<<< HEAD:Cinema/Cinema/reservation/PaymentLogin.cs
            int reservationCode = generator.Next(100000, 999999);

            WriteLine($"Your reservationcode is: {reservationCode}\n");

            /*WriteLine("Name: " + Registration.Name);
            WriteLine("E-mail: " + Registration.Email);
            WriteLine("Number: " + Registration.Number);
            WriteLine("Age: " + Registration.Age);*/

            //convert_cs_to_json();
            //ReservationFormat.Account();
            //Reservation(Name, Email, Number, Age, reservationCode);
        }

        /*static void convert_cs_to_json()
        {
            var newreservation = new ReservationFormat();
            newreservation.ReservationCode = reservationCode;
            newreservation.Movies = "test";
            newreservation.Name = Registration.Name;
            newreservation.Email = Registration.Email;
            newreservation.Number = Registration.Number;
            newreservation.Age = Registration.Age;

            var newreservationJson = JsonConvert.SerializeObject(newreservation);

            static string JsonFileName() => Path.Combine("../../../data", "reservation.json");

            if (System.IO.File.Exists(JsonFileName()))
            {
                string reservationjsonfile = File.ReadAllText(JsonFileName());
                var reservationjson = JsonConvert.DeserializeObject(reservationjsonfile);
                File.Delete(JsonFileName());
                File.WriteAllText(JsonFileName(), "[" + reservationjsonfile.Substring(1, reservationjsonfile.Length - 2) + "," + newreservationJson + "\n]");
            }
        }*/

        private void Display()
        {
            WriteLine(Prompt);

========
            ReservationCode = generator.Next(100000, 999999);

            int reservationCode = Reservation.ReservationsAdd(ReservationCode, MovieId, TimeId, YourSeats, TotalPriceRoom, OrdersList, TotalPriceOrder, PersonalInfo);
            Time.TimesChange(TimeId, YourSeats);
            WriteLine($"Your reservationcode is: {reservationCode}\n");
        }

        private void Display()
        {
            WriteLine(Prompt);

>>>>>>>> main:Cinema/Cinema/reservation/Payment.cs
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
