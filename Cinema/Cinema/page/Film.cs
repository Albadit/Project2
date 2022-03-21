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
            string prompt = "Choice your film\n";
            string[] options = { "Movie: Uncharted, Age: 12, Genre: Action, Adventure", "Movie: The Batman, Age: 12, Genre: Action, Drama, Crime", "Movie: Spider-Man No Way Home, Age: 12, Genre: Action, Adventure",
                "Movie: Moonfall, Age: 12, Genre: Action, Science Fiction", "Movie: X, Age: 16, Genre: Horror", "Movie: Ambulance, Age: 16, Genre: Action, Thriller", "Movie: Blacklight, Age: 12, Genre: Action, Thriller",
                "Movie: Dog, Age: 12, Genre: Drama", "Movie: De Drekkies, Age: AL, Genre: Children's Movie", "Movie: Sing 2, Age: 6, Genre: Children's Movie\n", "Back" };
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
