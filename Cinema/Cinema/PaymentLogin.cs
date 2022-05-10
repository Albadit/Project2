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
    class paymentlogin
    {
        private int SelectedIndex;
        private string[] Options;
        private string Prompt;
        public static int reservationCode = 0;

        public paymentlogin(string title, string[] options)
        {
            Prompt = title;
            Options = options;
            SelectedIndex = 0;
        }

        private void Display()
        {
            WriteLine(Prompt);

            Write("Gebruikersnaam: ");
            var username = ReadLine();
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

            WriteLine("\n");
            WriteLine("Thank you for your reservation. Your reservation had been succesfully received.\n" +
            "You will receive a confirmation e-mail within 10 minutes.\n");

            Random generator = new Random();
            reservationCode = generator.Next(100000, 1000000);
            //random = reservationCode.ToString("000000");

            WriteLine("Your reservationcode is: " + reservationCode);

            WriteLine("Name: " + Registration.Name);
            WriteLine("E-mail: " + Registration.Email);
            WriteLine("Number: " + Registration.Number);
            WriteLine("Age: " + Registration.Age);

            convert_cs_to_json();

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
        static void convert_cs_to_json()
        {
            var newreservation = new ReservationFormat();
            newreservation.ReservationCode = reservationCode;
            newreservation.Movies = "test";
            newreservation.Name = Registration.Name;
            newreservation.Email = Registration.Email;
            newreservation.Number = Registration.Number;
            newreservation.Age = Registration.Age;

            var newreservationJson = JsonConvert.SerializeObject(newreservation);
            Console.WriteLine(newreservationJson);

            static string JsonFileName() => Path.Combine("data", "reservation.json");
            string fileName = @"C:\Users\31649\OneDrive - Hogeschool Rotterdam\Documents\GitHub\Project2\Cinema\Cinema\data\reservation.json";

            if (System.IO.File.Exists(fileName))
            {
                if (new FileInfo(fileName).Length == 0)
                {
                    File.WriteAllText(fileName, "[\n" + newreservationJson + "\n]");
                } else
                {
                    string reservationjsonfile = File.ReadAllText(fileName);
                    var reservationjson = JsonConvert.DeserializeObject(reservationjsonfile);
                    File.Delete(fileName);
                    File.WriteAllText(fileName, "[\n" + reservationjsonfile.Substring(1, reservationjsonfile.Length - 2) + "," + newreservationJson + "\n]");
                    Write(newreservationJson);
                }
            } else
            {
                File.WriteAllText(fileName, "[\n" + newreservationJson + "\n]");
            }
        }

        public class ReservationFormat
        {
            public int ReservationCode { get; set; } = 0;
            public string Movies { get; set; } = string.Empty;
            public string Name { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string Number { get; set; } = string.Empty;
            public int Age { get; set; } = 0;
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
