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
            List<string> filmNames = Movie.filmNames;

            List<string> filmList = Movie.filmList;
            filmList.Clear();

            Movie myMovie = new Movie();
            myMovie.Movies();
            filmList.Add("Back");

            string title = "Choice your film\n";
            string[] options = filmList.ToArray();
            Menu mainMenu = new Menu(title, options);
            int selectedIndex = mainMenu.Run();

            if (selectedIndex == options.Length - 1)
            {
                Home myHome = new Home();
                myHome.HomePage();
            }
            else
            {
                string filmName = filmNames[selectedIndex];
                Seats mySeating = new Seats();
                mySeating.SeatingPage(filmName);
            }
        }
    }
}
