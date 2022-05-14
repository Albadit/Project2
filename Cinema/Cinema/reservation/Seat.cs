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
            SelectedIndexHor = 0;
            SelectedIndexVer = 0;
        }

        public void RoomDraw()
        {
            int[][] seatList = TimeList[TimeId].Seats;
            int rows = seatList.Length;
            int columns = seatList[0].Length;
            string name = "Screen";

            Write("    ");
            for (int numRow = 1; numRow < columns + 1; numRow++)
            {
                if (numRow < 10) Write($"  {numRow}");
                else Write($" {numRow}");
            }
            Write("\n   +");

            for (int line = 0; line < columns + 1; line++)
            {
                if (line < columns) Write("---");
                else Write("--+");
            }
            WriteLine();

            for (int row = rows; row > 0; row--)
            {
                if (row < 10) Write($" {row} |");
                else Write($"{row} |");

                for (int column = 0; column < columns; column++)
                {
                    if (SelectedIndexHor == column && SelectedIndexVer == row - 1) { ForegroundColor = ConsoleColor.Green; }
                    else { ForegroundColor = ConsoleColor.White; BackgroundColor = ConsoleColor.Black; }

                    if (seatList[row - 1][column] == 0 && SelectedIndexHor == column && SelectedIndexVer == row - 1) { ForegroundColor = ConsoleColor.Red; Write("  X"); }
                    else if (seatList[row - 1][column] == 0) { Write("   "); }
                    else if (seatList[row - 1][column] == 1) { Write("  S"); }
                    else if (seatList[row - 1][column] == 2) { Write("  M"); }
                    else if (seatList[row - 1][column] == 3) { Write("  V"); }

                    if (seatList[row - 1][column] == 4 && SelectedIndexHor == column && SelectedIndexVer == row - 1) { ForegroundColor = ConsoleColor.Red; Write("  X"); }
                    else if (seatList[row - 1][column] == 4) { ForegroundColor = ConsoleColor.DarkYellow; Write("  X"); }
                    
                }
                ResetColor();
                Write("  |\n");
            }
            Write("   +");

            for (int line = 0; line < columns + 1; line++)
            {
                if (line < columns) Write("---");
                else Write("--+");
            }
            Write("\n     ");

            for (int align = 0; align < columns * 3; align++) Write("-");
            Write("\n     ");

            for (int text = 0; text < columns * 3 + 1 - name.Length; text++)
            {
                int interval = (int)Math.Floor(Convert.ToDouble(columns) * 3 / 2);
                int interval2 = (int)Math.Floor(Convert.ToDouble(name.Length) / 2);
                if (text == interval - interval2) Write(name);
                else Write(" ");
            }
            Write("\n");
        }

        private void Display(List<string> seatsList, decimal totalPriceRoom)
        {
            WriteLine(Prompt);

            RoomDraw();

            int value = Rooms[TimeList[TimeId].SeatId].Seats[SelectedIndexVer][SelectedIndexHor];
            if (value == 4) { Write("\nSorry this seat is already taken"); }
            else if (value == 0) { Write("\nSorry you can't select that seat"); }
            else { foreach (var item in seatsList) Write(item); }
            
            string price = totalPriceRoom.ToString("0.00", CultureInfo.InvariantCulture);
            WriteLine($"\n\nTotal price: {price}");

            WriteLine("\n\nPress Backspace to go back");
            ResetColor();
        }

        public (int[][], decimal) Run()
        {
            int[][] seatList = TimeList[TimeId].Seats;
            int[][] yourSeats = Array.Empty<int[]>(); 
            List<int> values = new();
            List<string> seatsList = new();
            decimal totalPriceRoom = 0;
            bool enter = false;

            ConsoleKey keyPressed;
            do
            {
                Clear();
                Display(seatsList, totalPriceRoom);
                int value = seatList[SelectedIndexVer][SelectedIndexHor];

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.Backspace)
                {
                    Times.TimesPage(MovieId);
                }

                else if (keyPressed == ConsoleKey.A)
                {
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
                }

                else if (keyPressed == ConsoleKey.D)
                {
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
                }

                else if(keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndexVer--;

                    if(SelectedIndexVer < 0)
                    {
                        SelectedIndexVer = Rooms[TimeList[TimeId].SeatId].Seats.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndexVer++;

                    if (SelectedIndexVer > Rooms[TimeList[TimeId].SeatId].Seats.Length - 1)
                    {
                        SelectedIndexVer = 0;
                    }
                }

                else if (keyPressed == ConsoleKey.RightArrow)
                {
                    SelectedIndexHor++;

                    if (SelectedIndexHor > Rooms[TimeList[TimeId].SeatId].Seats[0].Length - 1)
                    {
                        SelectedIndexHor = 0;
                    }
                }

                else if(keyPressed == ConsoleKey.LeftArrow)
                {
                    SelectedIndexHor--;

                    if (SelectedIndexHor < 0)
                    {
                        SelectedIndexHor = Rooms[TimeList[TimeId].SeatId].Seats[0].Length - 1;
                    }
                }

                else if (keyPressed == ConsoleKey.Enter)
                {
                    if (seatsList.Count != 0) enter = true;
                    else enter = false;
                }
            }
            while (!enter);

            return (yourSeats, totalPriceRoom);
        }
    }
}
