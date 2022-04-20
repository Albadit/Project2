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
            Write("Naam: ");
            var name = ReadLine();
            while (name == string.Empty)
            {
                WriteLine("Niet leeg laten!");
                Thread.Sleep(1000);
                Clear();
                WriteLine(Prompt);
                Write("Naam: ");
                name = ReadLine();
            }
            Name = Convert.ToString(name!);

            // Email
            Write("Email: ");
            var email = ReadLine();
            while (email == string.Empty)
            {
                WriteLine("Niet leeg laten!");
                Thread.Sleep(1000);
                Clear();
                WriteLine(Prompt);
                WriteLine("Naam: " + Name);
                Write("Email: ");
                email = ReadLine();
            }
            Email = Convert.ToString(email!);

            // Number
            Write("Nummer: ");
            var number = ReadLine();

            while (number == string.Empty)
            {
                WriteLine("Niet leeg laten!");
                Thread.Sleep(1000);
                Clear();
                WriteLine(Prompt);
                WriteLine("Naam: " + Name);
                WriteLine("Email: " + Email);
                Write("Nummer: ");
                number = ReadLine();
            }
            Number = Convert.ToString(number!);

            // Age
            Write("Leeftijd: ");
            var age = ReadLine();

            while (age == string.Empty)
            {
                WriteLine("Niet leeg laten!");
                Thread.Sleep(1000);
                Clear();
                WriteLine(Prompt);
                WriteLine("Name: " + Name);
                WriteLine("Email: " + Email);
                Write("Nummer: " + Number);
                Write("\nLeeftijd: ");
                age = ReadLine();
            }
            Age = Convert.ToInt32(age!);

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