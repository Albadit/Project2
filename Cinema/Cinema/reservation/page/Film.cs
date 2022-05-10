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
            (List<string> movieList, List<string> movieNames) = Movie.Movies();
            List<int> ageLists = Movie.MovieAge();
            movieList.Add("Back");

            string title = "Choice your film\n";
            string[] options = movieList.ToArray();
            Menu mainMenu = new(title, options);
            int selectedIndex = mainMenu.Run();

            if (selectedIndex == options.Length - 1)
            {
                Home.HomePage();
            }

            else
            {
                string movieName = movieNames[selectedIndex];
                int ageList = ageLists[selectedIndex];
                Seats.SeatPage(movieName, ageList);
            }
        }
    }
}
