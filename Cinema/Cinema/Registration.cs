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
    class Reservation
    {
        private int SelectedIndex;
        private string[] Options;
        private string Prompt;

        public Reservation(string title, string[] options)
        {
            Prompt = title;
            Options = options;
            SelectedIndex = 0;
        }

        private void Display()
        {

            WriteLine(Prompt);

            Write("Name: ");
            var Name = ReadLine();

            while (Name == string.Empty)
            {
                WriteLine("Niet leeg laten!");
                Thread.Sleep(1000);
                Clear();
                WriteLine(Prompt);
                Write("Name: ");
                Name = ReadLine();
            }

            Write("Email: ");
            var Email = ReadLine();
           
            while (Email == string.Empty)
            {
                WriteLine("Niet leeg laten!");
                Thread.Sleep(1000);
                Clear();
                WriteLine(Prompt);
                WriteLine("Name: " + Name);
                Write("Email: ");
                Email = ReadLine();
            }

            Write("Nummer: ");
            var Nummer = ReadLine();

            while (Nummer == string.Empty)
            {
                WriteLine("Niet leeg laten!");
                Thread.Sleep(1000);
                Clear();
                WriteLine(Prompt);
                WriteLine("Name: " + Name);
                WriteLine("Email: " + Email);
                Write("Nummer: ");
                Nummer = ReadLine();
            }

            Write("Leeftijd: ");
            var Leeftijd = ReadLine();

            /*if (Leeftijd )
            {
                Console.WriteLine("x is greater than y");
            }*/

            while (Leeftijd == string.Empty)
            {
                WriteLine("Niet leeg laten!");
                Thread.Sleep(1000);
                Clear();
                WriteLine(Prompt);
                WriteLine("Name: " + Name);
                WriteLine("Email: " + Email);
                Write("Nummer: " + Nummer);
                Write("\nLeeftijd: ");
                Leeftijd = ReadLine();
            }

            WriteLine("\n");

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
 