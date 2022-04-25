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
        public static void SeatPage(string filmName)
        {
            List<List<List<int>>> seatList = Room.Rooms();
            List<List<int>> seatSelect = seatList[0];


            string prompt = $"Choice your seat for the film: {filmName}\n";
            List<List<int>> options = seatSelect;
            Seat mainMenu = new(prompt, options);
            (int hor, int ver) = mainMenu.Run();

            if (hor + 1 == 1 && ver + 1 == 1)
            {
                Film.FilmPage();
            }

            /*if (selectedIndex <= options.Count - 2)
            {
                Pay.PayPage(filmName);
            }*/
        }
    }
}
