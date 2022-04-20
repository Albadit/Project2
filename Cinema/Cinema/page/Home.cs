using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.page
{
    class Home
    {
        public void HomePage()
        {
            string title = @"
       _______                           
      / ____(_)___  ___  ____ ___  ____ _
     / /   / / __ \/ _ \/ __ `__ \/ __ `/
    / /___/ / / / /  __/ / / / / / /_/ / 
    \____/_/_/ /_/\___/_/ /_/ /_/\__,_/  
    ";
            string[] options = { "Films", "Account","Exit" };
            Menu mainMenu = new Menu(title, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex) 
            { 
                case 0:
                    Film myFilm = new Film();
                    myFilm.FilmPage();
                    break;
                case 1:
                    Login myLogin = new Login();
                    myLogin.LoginPage();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
