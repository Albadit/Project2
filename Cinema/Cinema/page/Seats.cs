﻿using System;
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
            int[][] options = {
                new int[] { 1, 3, 5 },
                new int[] { 0, 2, 4 },
                new int[] { 11, 22, 12 }
            };
            Cinema.Seat mainMenu = new Cinema.Seat(prompt, options);
            int selectedIndex = mainMenu.Run();

            if (selectedIndex == options.Length - 1)
            {
                Film myFilm = new Film();
                myFilm.FilmPage();
            }

            if (selectedIndex == options.Length - 2)
            {
                Pay myPay = new Pay();
                myPay.PayPage(filmName);
            }
        }
    }
}
