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
        public static void SeatPage(int movieId, int timeId)
        {
            List<Movie> movies = Movie.Movies();

            string prompt = $"Choice your seat for the film: {movies[movieId].Name}\n";
            Seat mainMenu = new(prompt, movieId, timeId);
            (int[][] yourSeats, decimal totalPriceRoom) = mainMenu.Run();

            Orders.OrdersPage(movieId, timeId, yourSeats, totalPriceRoom);
        }
    }
}
