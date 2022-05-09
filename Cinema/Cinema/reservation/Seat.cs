﻿using Cinema.page;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        private readonly List<List<decimal>> SeatPrice;
        private readonly int RoomId;
        private readonly string Prompt;

        public Seat(string prompt, List<List<int>> options, List<List<decimal>> seatPrice, int roomId)
        {
            Prompt = prompt;
            Options = options;
            SeatPrice = seatPrice;
            RoomId = roomId;
            SelectedIndexHor = 0;
            SelectedIndexVer = 0;
        }

        public void RoomDraw()
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

        private void Display(List<string> seatsList, decimal totalPriceRoom, bool trigger)
        {
            WriteLine(Prompt);

            RoomDraw();

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
                    foreach (var item in seatsList) Write(item);
                }
            }
            string price = totalPriceRoom.ToString("0.00", CultureInfo.InvariantCulture);
            WriteLine($"\n\nTotal price: {price}");


            WriteLine("\n\nPress Backspace to go back");
            ResetColor();
        }

        public (List<List<int>>, List<string>, decimal) Run()
        {
            (List<List<List<int>>> seatList, List<List<decimal>> seatPrice) = Room.Rooms();
            List<List<int>> check = new();
            List<string> seatsList = new();
            decimal totalPriceRoom = 0;
            bool trigger = false;
            bool enter = false;

            ConsoleKey keyPressed;
            do
            {
                Clear();
                Display(seatsList, totalPriceRoom, trigger);

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.Backspace)
                {
                    Film.FilmPage();
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
                            int Price = 0;
                            for (int i = 0; i < seatPrice[RoomId].Count; i++)
                            {
                                if (i == Options[SelectedIndexVer][SelectedIndexHor])
                                {
                                    totalPriceRoom += SeatPrice[RoomId][i];
                                    Price = i;
                                    break;
                                }
                            }
                            int value = Options[SelectedIndexVer][SelectedIndexHor];
                            Options[SelectedIndexVer][SelectedIndexHor] = 4;
                            check.Add(new() { value, SelectedIndexVer, SelectedIndexHor });

                            string letter;
                            if (value == 1) letter = "S";
                            else if (value == 2) letter = "M";
                            else letter = "V";
                            seatsList.Add($"\n{letter} seat | row: {SelectedIndexVer + 1} | column: {SelectedIndexHor + 1} | Price: {seatPrice[RoomId][Price]}");
                        }
                    }
                    Display(seatsList, totalPriceRoom, trigger);
                }

                else if (keyPressed == ConsoleKey.D)
                {
                    if (Options[SelectedIndexVer][SelectedIndexHor] == 4)
                    {
                        for (int i = 0; i < check.Count; i++)
                        {
                            if (SelectedIndexVer == check[i][1] && SelectedIndexHor == check[i][2])
                            {
                                check.Remove(check[i]);
                                seatsList.Remove(seatsList[i]);
                                Options[SelectedIndexVer][SelectedIndexHor] = seatList[RoomId][SelectedIndexVer][SelectedIndexHor];
                                for (int j = 0; j < seatPrice[RoomId].Count; j++)
                                {
                                    if (j == Options[SelectedIndexVer][SelectedIndexHor])
                                    {
                                        totalPriceRoom -= SeatPrice[RoomId][j];
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                    }
                    Display(seatsList, totalPriceRoom, trigger);
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

                else if (keyPressed == ConsoleKey.Enter)
                {
                    if (check.Count != 0) enter = true;
                    else enter = false;
                }
            }
            while (!enter);

            return (Options, seatsList, totalPriceRoom);
        }
    }
}
