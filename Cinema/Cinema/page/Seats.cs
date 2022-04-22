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
            Room.Rooms();

            /*List<List<List<int>>> seatList = Room.seatList;*/

            List<List<int>> seatList2 = new List<List<int>>
            {
                new List<int> { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 },
                new List<int> { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 },
                new List<int> { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                new List<int> { 1, 1, 1, 1, 1, 2, 2, 1, 1, 1, 1, 1 },
                new List<int> { 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1 },
                new List<int> { 1, 1, 1, 2, 2, 3, 3, 2, 2, 1, 1, 1 },
                new List<int> { 1, 1, 1, 4, 4, 4, 3, 2, 2, 1, 1, 1 },
                new List<int> { 1, 1, 1, 2, 2, 3, 3, 2, 2, 1, 1, 1 },
                new List<int> { 1, 1, 1, 2, 2, 3, 3, 2, 2, 1, 1, 1 },
                new List<int> { 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1 },
                new List<int> { 1, 1, 1, 1, 1, 2, 2, 1, 1, 1, 1, 1 },
                new List<int> { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                new List<int> { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                new List<int> { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 }
            };

            string prompt = $"Choice your seat for the film: {filmName}\n";
            List<List<int>> options = seatList2;
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
