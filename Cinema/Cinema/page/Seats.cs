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
            /*int[][] Seats = Room.seatList2;*/

            /*Room myFilms = new Room();
            myFilms.Products();*/

            string prompt = $"Choice your seat for the film: {filmName}\n";
            int[][] options =
            {
                new int[] { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 },
                new int[] { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 },
                new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                new int[] { 1, 1, 1, 1, 1, 2, 2, 1, 1, 1, 1, 1 },
                new int[] { 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1 },
                new int[] { 1, 1, 1, 2, 2, 3, 3, 2, 2, 1, 1, 1 },
                new int[] { 1, 1, 1, 2, 2, 3, 3, 2, 2, 1, 1, 1 },
                new int[] { 1, 1, 1, 2, 2, 3, 3, 2, 2, 1, 1, 1 },
                new int[] { 1, 1, 1, 2, 2, 3, 3, 2, 2, 1, 1, 1 },
                new int[] { 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1 },
                new int[] { 1, 1, 1, 1, 1, 2, 2, 1, 1, 1, 1, 1 },
                new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                new int[] { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 },
            };
            Seat mainMenu = new Seat(prompt, options);
            int selectedIndex = mainMenu.Run();

            if (selectedIndex == options.Length - 1)
            {
                Film myFilm = new Film();
                myFilm.FilmPage();
            }

            if (selectedIndex <= options.Length - 2)
            {
                Pay myPay = new Pay();
                myPay.PayPage(filmName);
            }
        }
    }
}
