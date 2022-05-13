using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using static System.Console;

namespace Cinema.page
{
    class Times
    {
        public static void TimesPage(int movieId)
        { 
            List<Time> Times = Time.Times();
            List<string> timeList = new();

            foreach (var time in Times)
            {
                if (time.MovieId == movieId)
                {
                    int hour = time.Start[0] * 60;
                    double minutes = hour + time.Start[1] + time.Duration;
                    double minute = minutes / 60;
                    hour = (int)(minutes / 60);
                    int min = (int)((minute - (int)minute) * 60);

                    timeList.Add($"{time.Start[0]}:{time.Start[1]} till {hour}:{min}");
                }
            }
            timeList.Add("Back");

            string title;
            if (timeList.Count <= 1) title = "There is no movie available at this time\n";
            else title = "Choice your time\n";
            string[] options = timeList.ToArray();
            Menu mainMenu = new(title, options);
            int selectedIndex = mainMenu.Run();

            if (selectedIndex == options.Length - 1) Movies.MoviesPage();
            else Seats.SeatPage(movieId, Times[selectedIndex].Id);
        }
    }
}
