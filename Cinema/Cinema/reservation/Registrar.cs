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
    class Registrar
    {
        private int SelectedIndex;
        private readonly string[] Options;
        private readonly string Prompt;
        //private readonly string Name = string.Empty;
        //private readonly string Email;
        //private readonly string Number;
        //private readonly string Age;

        public Registrar(string title, string[] options)
        {
            Prompt = title;
            Options = options;
            SelectedIndex = 0;
        }

        public void Info()
        {
            // name
            Write("Full name: ");
            string? name = ReadLine();
            string patroon = @"^([a-zA-Z]{2,}\s[a-zA-Z]{1,}'?-?[a-zA-Z]{2,}\s?([a-zA-Z]{1,})?)";
           
            while (!Regex.IsMatch(name, patroon) || name == string.Empty)
            {
                if (name == string.Empty) WriteLine("\nDon't leave blank!");
                else WriteLine($"\n{name} is not a valid name!");
                Thread.Sleep(1000);
                Clear();
                WriteLine(Prompt);
                Write($"Full name: ");
                name = ReadLine();
            }

            // email
            Write("email: ");
            string? email = ReadLine();
            string pattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            
            while (!Regex.IsMatch(email, pattern) || email == string.Empty)
            {
                if (email == string.Empty) WriteLine("\nDon't leave blank!");
                else WriteLine($"\n{email} is not a valid email!");
                Thread.Sleep(1000);
                Clear();
                WriteLine(Prompt);
                WriteLine($"Full name: {name}");
                Write("Email: ");
                email = ReadLine();
            }

            // number
            Write("Phone Number: 06-");
            string? number = ReadLine();

            while (number.Length != 8 || number == string.Empty)
            {
                if (number == string.Empty) WriteLine("\nDon't leave blank!");
                else WriteLine($"\n{number} is not a valid number!");
                Thread.Sleep(1000);
                Clear();
                WriteLine(Prompt);
                WriteLine($"Full name: {name}");
                WriteLine($"Email: {email}");
                Write("Nummer: 06-");
                number = ReadLine();
            }

            // age
            Write("Leeftijd: ");
            string? age = ReadLine();
            while (age == string.Empty || age.All(char.IsDigit))
            {
                int ages = Convert.ToInt32(age);
                if (ages < 18) WriteLine("You are too young!");
                else if (age == string.Empty) WriteLine("\nDon't leave blank!");

                Thread.Sleep(1000);
                Clear();
                WriteLine(Prompt);
                WriteLine($"Full name: {name}");
                WriteLine($"Email: {email}");
                WriteLine($"Number: 06-{number}");
                Write("Leeftijd: ");
                age = ReadLine();
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