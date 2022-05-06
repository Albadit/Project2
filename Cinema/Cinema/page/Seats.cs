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
            (List<List<List<int>>> seatList, List<decimal> seatPrice) = Room.Rooms();

            string prompt = $"Choice your seat for the film: {movieName}\n";
            Seat mainMenu = new(prompt, seatList[0], seatPrice);
            List<List<int>> room = mainMenu.Run();

            if (true)
            {
                Orders.OrdersPage(movieName, room);
            }
        }
    }
}
