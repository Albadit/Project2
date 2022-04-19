﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.page
{
    class Login
    {
        public void LoginPage()
        {
            string prompt = "Select you login screen\n";
            string[] options = { "Admin", "Reservation", "Back" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    break;
                case 1:
                    chooseScreen mychooseScreen = new chooseScreen();
                    mychooseScreen.chooseScreenPage();
                    break;
                case 2:
                    Home myHome = new Home();
                    myHome.HomePage();
                    break;
            }
        }
    }
}
