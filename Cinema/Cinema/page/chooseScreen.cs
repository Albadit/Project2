using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.page
{
    class chooseScreen
    {
        public void chooseScreenPage()
        {
            string title = "Do you have an account?\n";
            string[] options = { "Yes, login", "No, make an account", "Back" };
            Menu mainMenu = new Menu(title, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    break;
                case 1:
                    loginScreen myloginScreen = new loginScreen();
                    myloginScreen.loginScreenPage();
                    break;
                case 2:
                    Login myLogin = new Login();
                    myLogin.LoginPage();
                    break;     
            }
        }
    }
}
