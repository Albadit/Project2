using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Cinema.page
{
    class Seats
    {
        public void SeatingPage(string filmName)
        {        
            string prompt = $"Choice your seat for the film: {filmName}\n";
            string[] options = {
                "      1  2  3  4  5  6  7  8  9 10 11 12   ", 
                "   +--------------------------------------+",
                "14 |        S  S  S  S  S  S  S  S        |",
                "13 |     S  S  S  S  S  S  S  S  S  S     |",
                "12 |     S  S  S  S  S  S  S  S  S  S     |",
                "11 |  S  S  S  S  S  M  M  S  S  S  S  S  |",
                "10 |  S  S  S  S  M  M  M  M  S  S  S  S  |",
                " 9 |  S  S  S  M  M  V  V  M  M  S  S  S  |",
                " 8 |  S  S  S  M  M  V  V  M  M  S  S  S  |",
                " 7 |  S  S  S  M  M  V  V  M  M  S  S  S  |",
                " 6 |  S  S  S  M  M  V  V  M  M  S  S  S  |",
                " 5 |  S  S  S  S  M  M  M  M  S  S  S  S  |",
                " 4 |  S  S  S  S  S  M  M  S  S  S  S  S  |",
                " 3 |     S  S  S  S  S  S  S  S  S  S     |",
                " 2 |        S  S  S  S  S  S  S  S        |",
                " 1 |        S  S  S  S  S  S  S  S        |",
                "   +--------------------------------------+",
                "     ------------------------------------  ",
                "                    screen                 \n", 
                "Back" };
            Cinema.Seat mainMenu = new Cinema.Seat(prompt, options);
            int selectedIndex = mainMenu.Run();


            if (selectedIndex == options.Length - 1)
            {
                Film myFilm = new Film();
                myFilm.FilmPage();
            }

            switch (selectedIndex)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    Film myFilm = new Film();
                    myFilm.FilmPage();
                    break;
            }
        }
    }
}
