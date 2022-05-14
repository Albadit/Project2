using Cinema.page;
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
<<<<<<< HEAD
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
=======
        List<Room> Rooms = Room.Rooms();
        private int MovieId;
        private int TimeId;
        private readonly string Prompt;
        List<Time> TimeList = Time.Times();

        public Seat(string prompt, int movieId, int timeId)
        {
            Prompt = prompt;
            MovieId = movieId;
            TimeId = timeId;
>>>>>>> main
            SelectedIndexHor = 0;
            SelectedIndexVer = 0;
        }

        public void RoomDraw()
        {
<<<<<<< HEAD
            int rows = Options.Count;
            int columns = Options[0].Count;
=======
            int[][] seatList = TimeList[TimeId].Seats;
            int rows = seatList.Length;
            int columns = seatList[0].Length;
>>>>>>> main
            string name = "Screen";

            Write("    ");
            for (int numRow = 1; numRow < columns + 1; numRow++)
            {
<<<<<<< HEAD
                if (numRow < 10) { Write($"  {numRow}"); }
                else { Write($" {numRow}"); }
=======
                if (numRow < 10) Write($"  {numRow}");
                else Write($" {numRow}");
>>>>>>> main
            }
            Write("\n   +");

            for (int line = 0; line < columns + 1; line++)
            {
<<<<<<< HEAD
                if (line < columns) { Write("---"); }
                else { Write("--+"); }
=======
                if (line < columns) Write("---");
                else Write("--+");
>>>>>>> main
            }
            WriteLine();

            for (int row = rows; row > 0; row--)
            {
<<<<<<< HEAD
                if (row < 10) { Write($" {row} |"); }
                else { Write($"{row} |"); }
=======
                if (row < 10) Write($" {row} |");
                else Write($"{row} |");
>>>>>>> main

                for (int column = 0; column < columns; column++)
                {
                    if (SelectedIndexHor == column && SelectedIndexVer == row - 1) { ForegroundColor = ConsoleColor.Green; }
                    else { ForegroundColor = ConsoleColor.White; BackgroundColor = ConsoleColor.Black; }

<<<<<<< HEAD
                    if (Options[row - 1][column] == 0 && SelectedIndexHor == column && SelectedIndexVer == row - 1) { ForegroundColor = ConsoleColor.Red; Write("  X"); }
                    else if (Options[row - 1][column] == 0) { Write("   "); }
                    else if (Options[row - 1][column] == 1) { Write("  S"); }
                    else if (Options[row - 1][column] == 2) { Write("  M"); }
                    else if (Options[row - 1][column] == 3) { Write("  V"); }
                    if (Options[row - 1][column] == 4 && SelectedIndexHor == column && SelectedIndexVer == row - 1) { ForegroundColor = ConsoleColor.Red; Write("  X"); }
                    else if (Options[row - 1][column] == 4) { ForegroundColor = ConsoleColor.DarkYellow; Write("  X"); }
=======
                    if (seatList[row - 1][column] == 0 && SelectedIndexHor == column && SelectedIndexVer == row - 1) { ForegroundColor = ConsoleColor.Red; Write("  X"); }
                    else if (seatList[row - 1][column] == 0) { Write("   "); }
                    else if (seatList[row - 1][column] == 1) { Write("  S"); }
                    else if (seatList[row - 1][column] == 2) { Write("  M"); }
                    else if (seatList[row - 1][column] == 3) { Write("  V"); }

                    if (seatList[row - 1][column] == 4 && SelectedIndexHor == column && SelectedIndexVer == row - 1) { ForegroundColor = ConsoleColor.Red; Write("  X"); }
                    else if (seatList[row - 1][column] == 4) { ForegroundColor = ConsoleColor.DarkYellow; Write("  X"); }
>>>>>>> main
                    
                }
                ResetColor();
                Write("  |\n");
            }
            Write("   +");

            for (int line = 0; line < columns + 1; line++)
            {
<<<<<<< HEAD
                if (line < columns) { Write("---"); }
                else { Write("--+"); }
            }
            Write("\n     ");

            for (int align = 0; align < columns * 3; align++)
            {
                Write("-");
            }
=======
                if (line < columns) Write("---");
                else Write("--+");
            }
            Write("\n     ");

            for (int align = 0; align < columns * 3; align++) Write("-");
>>>>>>> main
            Write("\n     ");

            for (int text = 0; text < columns * 3 + 1 - name.Length; text++)
            {
                int interval = (int)Math.Floor(Convert.ToDouble(columns) * 3 / 2);
                int interval2 = (int)Math.Floor(Convert.ToDouble(name.Length) / 2);
<<<<<<< HEAD
                if (text == interval - interval2) { Write(name); }
                else { Write(" "); }
=======
                if (text == interval - interval2) Write(name);
                else Write(" ");
>>>>>>> main
            }
            Write("\n");
        }

<<<<<<< HEAD
        private void Display(List<string> seatsList, decimal totalPriceRoom, bool trigger)
=======
        private void Display(List<string> seatsList, decimal totalPriceRoom)
>>>>>>> main
        {
            WriteLine(Prompt);

            RoomDraw();

<<<<<<< HEAD
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


=======
            int value = Rooms[TimeList[TimeId].SeatId].Seats[SelectedIndexVer][SelectedIndexHor];
            if (value == 4) { Write("\nSorry this seat is already taken"); }
            else if (value == 0) { Write("\nSorry you can't select that seat"); }
            else { foreach (var item in seatsList) Write(item); }
            
            string price = totalPriceRoom.ToString("0.00", CultureInfo.InvariantCulture);
            WriteLine($"\n\nTotal price: {price}");

>>>>>>> main
            WriteLine("\n\nPress Backspace to go back");
            ResetColor();
        }

<<<<<<< HEAD
        public (List<List<int>>, List<string>, decimal) Run()
        {
            (List<List<List<int>>> seatList, List<List<decimal>> seatPrice) = Room.Rooms();
            List<List<int>> check = new();
            List<string> seatsList = new();
            decimal totalPriceRoom = 0;
            bool trigger = false;
=======
        public (int[][], decimal) Run()
        {
            int[][] seatList = TimeList[TimeId].Seats;
            int[][] yourSeats = Array.Empty<int[]>(); 
            List<int> values = new();
            List<string> seatsList = new();
            decimal totalPriceRoom = 0;
>>>>>>> main
            bool enter = false;

            ConsoleKey keyPressed;
            do
            {
                Clear();
<<<<<<< HEAD
                Display(seatsList, totalPriceRoom, trigger);
=======
                Display(seatsList, totalPriceRoom);
                int value = seatList[SelectedIndexVer][SelectedIndexHor];
>>>>>>> main

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.Backspace)
                {
<<<<<<< HEAD
                    Film.FilmPage();
=======
                    Times.TimesPage(MovieId);
>>>>>>> main
                }

                else if (keyPressed == ConsoleKey.A)
                {
<<<<<<< HEAD
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
=======
                    int[] seatPlace = Array.Empty<int>();
                    seatPlace = seatPlace.Concat(new int[] { seatList[SelectedIndexVer][SelectedIndexHor], SelectedIndexVer, SelectedIndexHor }).ToArray();

                    if (value != 0 && value != 4)
                    {
                        yourSeats = yourSeats.Concat(new int[][] { seatPlace }).ToArray();
                        totalPriceRoom += Rooms[TimeList[TimeId].SeatId].Price[value];
                        values.Add(value);
                        string letter;
                        if (value == 1) letter = "S";
                        else if (value == 2) letter = "M";
                        else letter = "V";
                        seatsList.Add($"\n{letter} seat | row: {SelectedIndexVer + 1} | column: {SelectedIndexHor + 1} | Price: {Rooms[TimeList[TimeId].SeatId].Price[value]}");
                        seatList[SelectedIndexVer][SelectedIndexHor] = 4;
                    }
                    Display(seatsList, totalPriceRoom);
>>>>>>> main
                }

                else if (keyPressed == ConsoleKey.D)
                {
<<<<<<< HEAD
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
=======
                    if (value == 4)
                    {
                        string letter;
                        int i = 0;
                        foreach (var list in seatsList)
                        {
                            if (values[i] == 1) letter = "S";
                            else if (values[i] == 2) letter = "M";
                            else letter = "V";
                            string seat = $"\n{letter} seat | row: {SelectedIndexVer + 1} | column: {SelectedIndexHor + 1} | Price: {Rooms[TimeList[TimeId].SeatId].Price[values[i]]}";

                            if (seat == list)
                            {
                                yourSeats = yourSeats.Except(new int[][] { yourSeats[i] }).ToArray();
                                seatsList.Remove(seatsList[i]);
                                totalPriceRoom -= Rooms[TimeList[TimeId].SeatId].Price[values[i]];
                                Rooms[TimeList[TimeId].SeatId].Seats[SelectedIndexVer][SelectedIndexHor] = values[i];
                                values.Remove(values[i]);
                                break;
                            }
                            i++;
                        }
                    }
                    Display(seatsList, totalPriceRoom);
>>>>>>> main
                }

                else if(keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndexVer--;

                    if(SelectedIndexVer < 0)
                    {
<<<<<<< HEAD
                        SelectedIndexVer = Options.Count - 1;
=======
                        SelectedIndexVer = Rooms[TimeList[TimeId].SeatId].Seats.Length - 1;
>>>>>>> main
                    }
                }
                else if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndexVer++;

<<<<<<< HEAD
                    if (SelectedIndexVer > Options.Count - 1)
=======
                    if (SelectedIndexVer > Rooms[TimeList[TimeId].SeatId].Seats.Length - 1)
>>>>>>> main
                    {
                        SelectedIndexVer = 0;
                    }
                }

                else if (keyPressed == ConsoleKey.RightArrow)
                {
                    SelectedIndexHor++;

<<<<<<< HEAD
                    if (SelectedIndexHor > Options[0].Count - 1)
=======
                    if (SelectedIndexHor > Rooms[TimeList[TimeId].SeatId].Seats[0].Length - 1)
>>>>>>> main
                    {
                        SelectedIndexHor = 0;
                    }
                }

                else if(keyPressed == ConsoleKey.LeftArrow)
                {
                    SelectedIndexHor--;

                    if (SelectedIndexHor < 0)
                    {
<<<<<<< HEAD
                        SelectedIndexHor = Options[0].Count - 1;
=======
                        SelectedIndexHor = Rooms[TimeList[TimeId].SeatId].Seats[0].Length - 1;
>>>>>>> main
                    }
                }

                else if (keyPressed == ConsoleKey.Enter)
                {
<<<<<<< HEAD
                    if (check.Count != 0) enter = true;
=======
                    if (seatsList.Count != 0) enter = true;
>>>>>>> main
                    else enter = false;
                }
            }
            while (!enter);

<<<<<<< HEAD
            return (Options, seatsList, totalPriceRoom);
=======
            return (yourSeats, totalPriceRoom);
>>>>>>> main
        }
    }
}
