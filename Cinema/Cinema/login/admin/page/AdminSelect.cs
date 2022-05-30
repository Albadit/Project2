﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.page
{
    class AdminSelect
    {
        public static void AdminSelectPage()
        {
            string prompt = $"Welcome Please select you reservation options.\n";
            string[] options = { "Register Movie", "Add Movie Date and Time", "Back" };
            Menu mainMenu = new(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    RegisterMovie.RegisterMoviePage();
                    break;
                case 1:
                    MovieSelect.MovieDateTimePage();
                    break;
                case 2:
                    Login.LoginPage();
                    break;
            }
           
        }
    }
}
