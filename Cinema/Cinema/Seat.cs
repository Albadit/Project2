using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Cinema
{
    class Seat
    {
        private int SelectedIndexHor;
        private int SelectedIndexVer;
        private int[][] Options;
        private string Prompt;

        public Seat(string prompt, int[][] options)
        {
            Prompt = prompt;
            Options = options;
            SelectedIndexHor = 0;
            SelectedIndexVer = 0;
        }

        private void Display()
        {
            WriteLine(Prompt);

            string display = string.Empty;
            foreach (int[] row in Options)
            {
                foreach (int column in row)
                {
                    display += column + " ";
                }
                // move to the next line
                display += "\n";
            }
            Console.WriteLine(display);
            /*for (int i = 0; i < Options.Length; i++)
            {
                int currentOptions = Options[i][1];

                if (SelectedIndexVer == i)
                {
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                }
                WriteLine($" {currentOptions}");
            }*/
            /*ResetColor();*/
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
                    SelectedIndexVer--;

                    if(SelectedIndexVer < 0)
                    {
                        SelectedIndexVer = Options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndexVer++;

                    if (SelectedIndexVer > Options.Length - 1)
                    {
                        SelectedIndexVer = 0;
                    }
                }

                else if (keyPressed == ConsoleKey.RightArrow)
                {
                    SelectedIndexHor++;

                    if (SelectedIndexHor > Options.Length - 1)
                    {
                        SelectedIndexHor = 0;
                    }
                }

                else if(keyPressed == ConsoleKey.LeftArrow)
                {
                    SelectedIndexHor--;

                    if (SelectedIndexHor < 0)
                    {
                        SelectedIndexHor = Options.Length - 1;
                    }
                }
            }
            while (keyPressed != ConsoleKey.Enter);

            return SelectedIndexVer + SelectedIndexHor;
        }
    }
}
