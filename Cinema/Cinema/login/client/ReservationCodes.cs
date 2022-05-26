using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Cinema.page
{
    class ReservationCodes
    {
        private int SelectedIndex;
        private string Prompt;
        List<Reservation> Reservations = Reservation.Reservations();

        public ReservationCodes(string title)
        {
            Prompt = title;
            SelectedIndex = 0;
        }

        public void Code()
        {
            Write("ReservationCode: ");
            string? code = ReadLine();
            string codes = code ?? string.Empty;
            int codess = 0;
            if (codes.All(char.IsNumber) && code != string.Empty) codess = Convert.ToInt32(code);

            for (int i = 0; i < Reservations.Count; i++)
            {
                if (codess == Reservations[i].ReservationCode)
                {
                    AdminSelect.ReservationSelectPage(i);
                    break;
                }
            }

            while (!(codess >= 100000 && codess <= 999999) || code == string.Empty || !codes.All(char.IsNumber))
            {
                if (!(codess >= 100000 && codess <= 999999)) WriteLine("\nYou need to have six numbers");
                else if (code == string.Empty) WriteLine("\nDon't leave blank!");
                else WriteLine($"\n{codes} is not a valid name!");
                Thread.Sleep(2000);
                Clear();
                Login.LoginPage();
            }

            if (codess >= 100000 && codess <= 999999)
            {
                WriteLine("\nThis reservation doesn't exist");
                Thread.Sleep(2000);
                Clear();
                Login.LoginPage();
            }
            WriteLine();
        }

        private void Display()
        {
            WriteLine(Prompt);
            Code();
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
            }
            while (keyPressed != ConsoleKey.Enter);

            return SelectedIndex;
        }
    }
}
