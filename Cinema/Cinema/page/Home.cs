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
            string prompt = "Welcome to Cinema Ultimate ultra super sonic 16k 5D\n";
            string[] options = { "Films", "Account\n", "Exit" };
            Menu mainMenu = new Menu(prompt, options);
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
