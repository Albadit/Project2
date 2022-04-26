using Cinema.page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Console;

namespace Cinema
{
    class Registration
    {
        private int SelectedIndex;
        private string[] Options;
        private string Prompt;
        public static string Name = string.Empty;
        public static string Email = string.Empty;
        public static string Number = string.Empty;
        public static int Age = 0;

        public Registration(string title, string[] options)
        {
            Prompt = title;
            Options = options;
            SelectedIndex = 0;
        }

        public void Info()
        {
            // Name
            Write("(1) Voor- en achternaam: ");
            var name = ReadLine();
            string patroon = @"^([a-zA-Z]{2,}\s[a-zA-Z]{1,}'?-?[a-zA-Z]{2,}\s?([a-zA-Z]{1,})?)";

            while (name == string.Empty)
            {
                WriteLine("\nNiet leeg laten!");
                Thread.Sleep(1000);
                Clear();
                WriteLine(Prompt);
                Write("(1) Voor- en achternaam: ");
                name = ReadLine();
            }

            while (!Regex.IsMatch(name, patroon))
            {
                if (name == string.Empty)
                {
                    WriteLine("\nNiet leeg laten!");
                    Thread.Sleep(1000);
                    Clear();
                    WriteLine(Prompt);
                    Write("(1) Voor- en achternaam: ");
                    name = ReadLine();
                }
                else
                {
                    WriteLine("\n" + name + " is geen geldige naam!");
                    Thread.Sleep(1000);
                    Clear();
                    WriteLine(Prompt);
                    Write("(1) Voor- en achternaam: " + Name);
                    name = ReadLine();
                }
            }

            Name = Convert.ToString(name!);


            // Email
            Write("(2) Email: ");
            var email = ReadLine();
            string pattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

            while (email == string.Empty)
            {
                WriteLine("\nNiet leeg laten!");
                Thread.Sleep(1000);
                Clear();
                WriteLine(Prompt);
                WriteLine("(1) Voor- en achternaam: " + Name);
                Write("(2) Email: ");
                email = ReadLine();
            }

            while (!Regex.IsMatch(email, pattern))
            {
                if (email == string.Empty)
                {
                    WriteLine("\nNiet leeg laten!");
                    Thread.Sleep(1000);
                    Clear();
                    WriteLine(Prompt);
                    WriteLine("(1) Voor- en achternaam: " + Name);
                    Write("(2) Email: ");
                    email = ReadLine();
                }
                else
                {
                    WriteLine("\n" + email + " is geen geldige email address!");
                    Thread.Sleep(1000);
                    Clear();
                    WriteLine(Prompt);
                    WriteLine("(1) Voor- en achternaam: " + Name);
                    Write("(2) Email: ");
                    email = ReadLine();
                }
            }

            Email = Convert.ToString(email!);

            // Number
            Write("(3) Nummer: 06-");
            var number = ReadLine();

            while (number.Length < 8)
            {
                if (number == string.Empty)
                {
                    WriteLine("Niet leeg laten!");
                    Thread.Sleep(1000);
                    Clear();
                    WriteLine(Prompt);
                    WriteLine("(1) Voor- en achternaam: " + Name);
                    WriteLine("(2) Email: " + Email);
                    Write("(3) Nummer: 06-");
                    number = ReadLine();
                }
                else
                {
                    WriteLine("Vul een geldige nummer in!");
                    Thread.Sleep(1000);
                    Clear();
                    WriteLine(Prompt);
                    WriteLine("(1) Voor- en achternaam: " + Name);
                    WriteLine("(2) Email: " + Email);
                    Write("(3) Nummer: 06-");
                    number = ReadLine();
                }
               
            }

            
            Number = Convert.ToString(number!);

            // Age
            Write("(4) Leeftijd: ");
            var age = ReadLine();

            while (age == string.Empty)
            {
                WriteLine("Niet leeg laten!");
                Thread.Sleep(1000);
                Clear();
                WriteLine(Prompt);
                WriteLine("(1) Name: " + Name);
                WriteLine("(2) Email: " + Email);
                Write("(3) Nummer: 06-" + Number);
                Write("\n(4) Leeftijd: ");
                age = ReadLine();
            }

            Age = Convert.ToInt32(age!);

            if (Age < 18)
            {
                WriteLine("\nJij bent te jong!");
                Thread.Sleep(1000);
                Film myFilm = new Film();
                Film.FilmPage();
            }

            WriteLine("\n");
        }

        private void Display()
        {

            WriteLine(Prompt);

            Info();

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