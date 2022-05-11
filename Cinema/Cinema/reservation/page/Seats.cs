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
        public static void SeatPage(int movieId)
        {
            List<Movie> movies = Movie.Movies();
            List<Room> rooms = Room.Rooms();
            int roomId = 0;

            string prompt = $"Choice your seat for the film: {movies[movieId].Name}\n";
            Seat mainMenu = new(prompt, rooms, roomId);
            (int[][] yourSeats, decimal totalPriceRoom) = mainMenu.Run();

            Orders.OrdersPage(movieId, yourSeats, totalPriceRoom);
        }
    }
}
