using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.page
{
    class Home
    {
        public static void HomePage()
        {
            string title = @"
       _______                           
      / ____(_)___  ___  ____ ___  ____ _
     / /   / / __ \/ _ \/ __ `__ \/ __ `/
    / /___/ / / / /  __/ / / / / / /_/ / 
    \____/_/_/ /_/\___/_/ /_/ /_/\__,_/  
    ";
            string[] options = { "Films", "Account", "Exit" };
            Menu mainMenu = new(title, options);
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
