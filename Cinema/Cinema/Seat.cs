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
        private readonly List<List<int>> Options;
        private readonly string Prompt;

        public Seat(string prompt, List<List<int>> options)
        {
            Prompt = prompt;
            Options = options;
            SelectedIndexHor = 0;
            SelectedIndexVer = 0;
        }

        public void RoomDraw(List<List<int>> check)
        {
            int rows = Options.Count;
            int columns = Options[0].Count;
            string name = "Screen";

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
                else { Write("--+"); }
            }
            WriteLine();

            for (int row = rows; row > 0; row--)
            {
                if (row < 10) { Write($" {row} |"); }
                else { Write($"{row} |"); }

                for (int column = 0; column < columns; column++)
                {
                    if (SelectedIndexHor == column && SelectedIndexVer == row - 1) { ForegroundColor = ConsoleColor.Green; }
                    else { ForegroundColor = ConsoleColor.White; BackgroundColor = ConsoleColor.Black; }

                    if (Options[row - 1][column] == 0 && SelectedIndexHor == column && SelectedIndexVer == row - 1) { ForegroundColor = ConsoleColor.Red; Write("  X"); }
                    else if (Options[row - 1][column] == 0) { Write("   "); }
                    else if (Options[row - 1][column] == 1) { Write("  S"); }
                    else if (Options[row - 1][column] == 2) { Write("  M"); }
                    else if (Options[row - 1][column] == 3) { Write("  V"); }
                    if (Options[row - 1][column] == 4 && SelectedIndexHor == column && SelectedIndexVer == row - 1) { ForegroundColor = ConsoleColor.Red; Write("  X"); }
                    else if (Options[row - 1][column] == 4) { ForegroundColor = ConsoleColor.DarkYellow; Write("  X"); }
                    /*if (check.Count > row)
                    {
                        if (check[SelectedIndexVer][SelectedIndexHor] == Options[row - 1][column])
                        {
                            ForegroundColor = ConsoleColor.Yellow; Write("  X");
                        }
                    }*/
                    
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
            Write("\n");
        }

        private void Display(List<List<int>> check, bool trigger)
        {
            WriteLine(Prompt);

            RoomDraw(check);

            if (trigger) { 
                if (Options[SelectedIndexVer][SelectedIndexHor] == 4)
                {
                    Write("\nSorry this seat is already taken");
                }
                else if (Options[SelectedIndexVer][SelectedIndexHor] == 0)
                {
                    Write("\nSorry you can't select that seat");
                }
                else
                {
                    foreach (var item in check)
                    {
                        Write($"\nYour {item[0]} selected row {item[1] + 1} on column {item[2] + 1}");
                    }
                }
            }

            WriteLine("\n\nPress Backspace to go back");
            ResetColor();
        }

        public (int, int) Run()
        {
            List<List<int>> check = new();
            int count = 0;
            bool trigger = false;

            ConsoleKey keyPressed;
            do
            {
                Clear();
                Display(check, trigger);

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.Backspace)
                {
                    Film.FilmPage();
                }

                else if (keyPressed == ConsoleKey.Spacebar)
                {
                    /*Orders.OrdersPage(movieName);*/
                }

                else if (keyPressed == ConsoleKey.A)
                {
                    bool aprove = true;
                    trigger = true;
                    if (Options[SelectedIndexVer][SelectedIndexHor] != 0 && Options[SelectedIndexVer][SelectedIndexHor] != 4)
                    {
                        if (check.Count != 0)
                        {
                            for (int i = 0; i < check.Count; i++)
                            {
                                if (SelectedIndexVer == check[i][1] && SelectedIndexHor == check[i][2])
                                {
                                    aprove = false;
                                    break;
                                }
                            }
                        }
                        
                        if (aprove)
                        {
                            count++;
                            check.Add(new() { count, SelectedIndexVer, SelectedIndexHor });
                        }
                        
                    }
                    Display(check, trigger);
                }

                else if(keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndexVer--;

                    if(SelectedIndexVer < 0)
                    {
                        SelectedIndexVer = Options.Count - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndexVer++;

                    if (SelectedIndexVer > Options.Count - 1)
                    {
                        SelectedIndexVer = 0;
                    }
                }

                else if (keyPressed == ConsoleKey.RightArrow)
                {
                    SelectedIndexHor++;

                    if (SelectedIndexHor > Options[0].Count - 1)
                    {
                        SelectedIndexHor = 0;
                    }
                }

                else if(keyPressed == ConsoleKey.LeftArrow)
                {
                    SelectedIndexHor--;

                    if (SelectedIndexHor < 0)
                    {
                        SelectedIndexHor = Options[0].Count - 1;
                    }
                }
            }
            while (keyPressed != ConsoleKey.Enter);

            return (SelectedIndexHor, SelectedIndexVer);
        }
    }
}
