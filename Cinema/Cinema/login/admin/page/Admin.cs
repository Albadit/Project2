using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.page
{
    class Admin
    {
        public static void AdminPage()
        {
            string Prompt = "Please fill in your username and password.\n";
            AdminLogin mainMenu = new(Prompt);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Movies.MoviesPage();
                    break;
                case 1:
                    Login.LoginPage();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
