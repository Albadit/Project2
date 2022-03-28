using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using static System.Console;

namespace Cinema.page
{
    class Film
    {
        public void FilmPage()
        {
            string prompt = "Choice your film\n";
            string[] options = { "Uncharted", "The Batman", "Spider-Man No Way Home", "Moonfall", "X", "Ambulance", "Blacklight", "Dog", "De Drekkies", "Sing 2\n", "Back" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            if (selectedIndex == options.Length - 1)
            {
                Home myHome = new Home();
                myHome.HomePage();
            }
            else
            {
                string filmName = options[selectedIndex].Replace("\n", String.Empty);
                Seats mySeating = new Seats();
                mySeating.SeatingPage(filmName);
            }
        }
    }
}
