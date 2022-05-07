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
            (List<List<List<int>>> seatList, List<List<decimal>> seatPrice) = Room.Rooms();
            int roomId = 1;

            string prompt = $"Choice your seat for the film: {movieName}\n";
            Seat mainMenu = new(prompt, seatList[roomId], seatPrice, roomId);
            (List<List<int>> room, decimal totalPriceRoom)  = mainMenu.Run();

            if (true)
            {
                Orders.OrdersPage(movieName, room, totalPriceRoom);
            }
        }
    }
}
