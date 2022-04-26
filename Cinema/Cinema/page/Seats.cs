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
        public static void SeatPage(string movieName)
        {
            List<List<List<int>>> seatList = Room.Rooms();
            List<List<int>> seatSelect = seatList[0];


            string prompt = $"Choice your seat for the film: {movieName}\n";
            List<List<int>> options = seatSelect;
            Seat mainMenu = new(prompt, options);
            (int hor, int ver) = mainMenu.Run();

            if (true)
            {
                Orders.OrdersPage(movieName);
            }
        }
    }
}
