﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using static System.Console;

namespace Cinema.page
{
    class Dates
    {
        public static void DatesPage(int movieId)
        { 
            List<Datetime> Dates = Datetime.Times();
            List<string> dateList = new();

            foreach (var date in Dates)
            {
                if (date.MovieId == movieId)
                {
                    DateTime dates = new(date.Date[0], date.Date[1], date.Date[2]);
                    dateList.Add($"{dates:dd MMMM yyyy}");
                }
            }
          
            for (int i = 0; i < dateList.Count; i++)
            {
                int count = 0;
                for (int j = 0; j < dateList.Count; j++)
                {
                    if (dateList[i] == dateList[j]) count++;
                }
                if (count >= 2) dateList.RemoveAt(i);
            }
            dateList.Add("Back");

            string title;
            if (dateList.Count <= 1) title = "There is no movie available at this date.\n";
            else title = "Choice your date.\n";
            string[] options = dateList.ToArray();
            Menu mainMenu = new(title, options);
            int selectedIndex = mainMenu.Run();

            if (selectedIndex == options.Length - 1) Movies.MoviesPage();
            else Times.TimesPage(movieId, dateList[selectedIndex]);
        }
    }
}
