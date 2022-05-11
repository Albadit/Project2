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
    class Books
    {
        private int SelectedIndex;
        private readonly string[] Options;
        private readonly string Prompt;
        private readonly int AgeList;
        private string Name;
        private string Email;
        private string Number;
        private string Age;
        private string[] Information;

        public Books(string title, string[] options, int ageList)
        {
            Prompt = title;
            Options = options;
            AgeList = ageList;
            SelectedIndex = 0;
            Name = string.Empty;
            Email = string.Empty;
            Number = string.Empty;
            Age = string.Empty;
            Information = Array.Empty<string>();
        }

        public void Info()
        {
            // name
            Write("Full name: ");
            string? name = ReadLine();
            string patroon = @"^([a-zA-Z]{2,}\s[a-zA-Z]{1,}'?-?[a-zA-Z]{2,}\s?([a-zA-Z]{1,})?)";
            string names = name ?? string.Empty;
            while (!Regex.IsMatch(names, patroon) || name == string.Empty)
            {
                if (name == string.Empty) WriteLine("\nDon't leave blank!");
                else WriteLine($"\n{name} is not a valid name!");
                Thread.Sleep(1000);
                Clear();
                WriteLine(Prompt);
                Write($"Full name: ");
                name = ReadLine();
                names = name ?? string.Empty;
            }

            // email
            Write("email: ");
            string? email = ReadLine();
            string pattern = @"\A(?:[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?)\Z";
            string emails = email ?? string.Empty;
            while (!Regex.IsMatch(emails, pattern) || email == string.Empty)
            {
                if (email == string.Empty) WriteLine("\nDon't leave blank!");
                else WriteLine($"\n{email} is not a valid email!");
                Thread.Sleep(1000);
                Clear();
                WriteLine(Prompt);
                WriteLine($"Full name: {name}");
                Write("Email: ");
                email = ReadLine();
                emails = email ?? string.Empty;
            }

            // number
            Write("Phone Number: 06-");
            string? number = ReadLine();
            string numbers = number ?? string.Empty;
            while (numbers.Length != 8 || number == string.Empty || !numbers.All(char.IsNumber))
            {
                if (number == string.Empty) WriteLine("\nDon't leave blank!");
                else WriteLine($"\n06-{number} is not a valid number!");
                Thread.Sleep(1000);
                Clear();
                WriteLine(Prompt);
                WriteLine($"Full name: {name}");
                WriteLine($"Email: {email}");
                Write("Nummer: 06-");
                number = ReadLine();
                numbers = number ?? string.Empty;
            }

            // age
            Write("Leeftijd: ");
            string? age = ReadLine();
            string agess = age ?? string.Empty;
            int ages = 0;
            if (agess.All(char.IsNumber) && age != string.Empty) ages = Convert.ToInt32(age);

            while (age == string.Empty || ages < AgeList || !agess.All(char.IsNumber))
            {
                if (ages > 0 && ages < AgeList) WriteLine("\nYou are too young!");
                else if (age == string.Empty) WriteLine("\nDon't leave blank!");
                else WriteLine($"\n{age} is not a valid age!");
                Thread.Sleep(1000);
                Clear();
                if (ages > 0 && ages < AgeList) Home.HomePage();
                WriteLine(Prompt);
                WriteLine($"Full name: {name}");
                WriteLine($"Email: {email}");
                WriteLine($"Number: 06-{number}");
                Write("Leeftijd: ");
                age = ReadLine();
                agess = age ?? string.Empty;
                if (agess.All(char.IsNumber) && age != string.Empty) ages = Convert.ToInt32(age);
            }
            WriteLine();

            Name = name ?? string.Empty;
            Email = email ?? string.Empty;
            Number = number ?? string.Empty;
            Age = age ?? string.Empty;

            Information = Information.Concat(new string[] { Name, Email, Number, Age }).ToArray();
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

        public (int, string[]) Run()
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

            return (SelectedIndex, Information);
        }
    }
}