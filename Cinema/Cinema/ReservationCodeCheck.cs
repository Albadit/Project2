using Cinema.page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Cinema
{
    class ReservationCodeCheck
    {
        private int SelectedIndex;
        private string[] Options;
        private string Prompt;

        public ReservationCodeCheck(string title, string[] options)
        {
            Prompt = title;
            Options = options;
            SelectedIndex = 0;
        }

        public void ReservationChecks()
        {
            ReservationCheck myReservationCode = new ReservationCheck();
            myReservationCode.Reservations();

            bool checks = false;
            Write("Reservation Code: ");
            var reservationcode = ReadLine();
            int ReservationCode = Convert.ToInt32(reservationcode);
            List<int> checkList = ReservationCheck.checkList;
            List<string> ReservationList = ReservationCheck.ReservationList;
            int i = 0;

            foreach (int check in checkList.ToArray())
            {
                if (ReservationCode == check)
                {
                    Write(ReservationList[i]) ;
                    checks = true;
                }
                i++;
            }

            if (checks == false)
            {
                Write("Reservation code is not know. Please try agian.");
            }
        }

        private void Display()
        {
            WriteLine(Prompt);
            
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
            ReservationChecks();
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

                if(keyPressed == ConsoleKey.Backspace)
                {
                    chooseScreen mychooseScreen = new chooseScreen();
                    mychooseScreen.chooseScreenPage();
                }

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
