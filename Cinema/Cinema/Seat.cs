using Cinema.page;
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
            int rows = Options.Length;
            int columns = Options[0].Length;
            string name = "Screen";
            WriteLine(Prompt);

            Write("    ");
            for (int numRow = 1; numRow < columns + 1; numRow++)
            {
                if (numRow < 10) { Write($"  {numRow}"); }
                else { Write($" {numRow}"); }
            }
            Write("\n   +");

            for (int line = 0; line < columns + 1; line++)
            {
                if (line < columns) { Write("---"); }
                else { Write ("--+"); }
            }
            WriteLine();

            for (int row = rows; row > 0; row--)
            {
                if (row < 10) { Write($" {row} |"); }
                else { Write($"{row} |"); }
                
                for (int column = 0; column < columns; column++)
                {
                    if (SelectedIndexHor == column && SelectedIndexVer == row - 1) { ForegroundColor = ConsoleColor.Red; }
                    else { ForegroundColor = ConsoleColor.White; BackgroundColor = ConsoleColor.Black; }

                    if (Options[row - 1][column] == 0 && SelectedIndexHor == column && SelectedIndexVer == row - 1) { BackgroundColor = ConsoleColor.Red; }

                    if      (Options[row-1][column] == 0) { Write("   "); }
                    else if (Options[row-1][column] == 1) { Write("  S"); }
                    else if (Options[row-1][column] == 2) { Write("  M"); }
                    else if (Options[row-1][column] == 3) { Write("  V"); }
                    else                                  { Write("  X"); }
                }
                ResetColor();
                Write("  |\n");
            }
            Write("   +");

            for (int line = 0; line < columns + 1; line++)
            {
                if (line < columns) { Write("---"); }
                else { Write("--+"); }
            }
            Write("\n     ");

            for (int align = 0; align < columns * 3; align++)
            {
               Write("-");
            }
            Write("\n     ");

            for (int text = 0; text < columns * 3 + 1 - name.Length; text++)
            {
                int interval = (int)Math.Floor(Convert.ToDouble(columns) * 3 / 2);
                int interval2 = (int)Math.Floor(Convert.ToDouble(name.Length) / 2);
                if (text == interval - interval2) { Write(name); }
                else { Write(" "); }
            }

            /*WriteLine(display);*/
            WriteLine();
            WriteLine("Press Backspace to go back");
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
                    Film myFilm = new Film();
                    myFilm.FilmPage();
                }

                if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndexVer--;

                    if(SelectedIndexVer < 0)
                    {
                        SelectedIndexVer = Options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.UpArrow)
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

                    if (SelectedIndexHor > Options.Length - 3)
                    {
                        SelectedIndexHor = 0;
                    }
                }

                else if(keyPressed == ConsoleKey.LeftArrow)
                {
                    SelectedIndexHor--;

                    if (SelectedIndexHor < 0)
                    {
                        SelectedIndexHor = Options.Length - 3;
                    }
                }
            }
            while (keyPressed != ConsoleKey.Enter);

            return SelectedIndexVer + SelectedIndexHor;
        }
    }
}
