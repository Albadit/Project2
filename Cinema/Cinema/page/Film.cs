using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Cinema.page
{
    class Film
    {
        public void FilmPage()
        {
            /*Movie myMovie = new Movie();
            string[] films = myMovie.Movies();*/

            /*films = $"{myMovie.Name}\n {myMovie.Genre}\n {myMovie.Age}";*/

            string prompt = "Choice your film\n";
            string[] options = { "Uncharted", "The Batman", "Spider-Man No Way Home\n", "Back" };
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
                Seating mySeating = new Seating();
                mySeating.SeatingPage(filmName);
            }
        }
    }
}
