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
        public static void TimesPage(int movieId, string datetime)
        { 
            List<Datetime> Times = Datetime.Times();
            List<string> timeList = new();
            List<int> datetimeId = new();

            foreach (var time in Times)
            {
                DateTime date = new(time.Date[0], time.Date[1], time.Date[2]);
                string dates = ($"{date:dd MMMM yyyy}");

                if (time.MovieId == movieId && dates == datetime)
                {
                    datetimeId.Add(time.Id);
                    int hour = time.Start[0] * 60;
                    double minutes = hour + time.Start[1] + time.Duration;
                    double minute = minutes / 60;
                    hour = (int)(minutes / 60);
                    int min = (int)((minute - (int)minute) * 60);

                    string dzero = time.Start[1].ToString();
                    if (dzero == "0") { dzero = "00"; }

                    timeList.Add($"{time.Start[0]}:{dzero} - {hour}:{min}");
                }
            }
            timeList.Add("Back");

            string title = "Choice your time.\n";
            string[] options = timeList.ToArray();
            Menu mainMenu = new(title, options);
            int selectedIndex = mainMenu.Run();

            if (selectedIndex == options.Length - 1) Dates.DatesPage(movieId);
            else Seats.SeatPage(movieId, datetimeId[selectedIndex]);
        }
    }
}
