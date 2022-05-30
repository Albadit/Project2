using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Cinema.page
{
    class AdminLogin
    {
        private int SelectedIndex;
        private string Prompt;

        public AdminLogin(string title)
        {
            Prompt = title;
            SelectedIndex = 0;
        }

        private void Display()
        {
            WriteLine(Prompt);
            Write("Enter username: ");
            string? username = ReadLine();
            Write("Enter password: ");
            string? password = ReadLine();

            while (username != "admin" || password != "admin")
            {
                WriteLine("\nUsername or password is incorrect, please try again.\n");
                Thread.Sleep(1000);
                Clear();
                WriteLine(Prompt);
                Write("Enter username: ");
                username = ReadLine();
                Write("Enter password: ");
                password = ReadLine();
            }

            WriteLine("\nLogin successful");
            Thread.Sleep(1000);
            Clear();
            AdminSelect.AdminSelectPage();
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
