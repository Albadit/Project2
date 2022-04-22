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
        public static void FilmPage()
        {
            List<string> filmNames = Movie.filmNames;
            List<string> filmList = Movie.filmList;
            filmList.Clear();

            Movie.Movies();

            filmList.Add("Back");

            string title = "Choice your film\n";
            string[] options = filmList.ToArray();
            Menu mainMenu = new(title, options);
            int selectedIndex = mainMenu.Run();

            if (selectedIndex == options.Length - 1)
            {
                Home.HomePage();
            }

            else
            {
                string filmName = filmNames[selectedIndex];
                Seats.SeatPage(filmName);
            }
        }
    }
}
