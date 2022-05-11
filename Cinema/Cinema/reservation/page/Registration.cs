
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.page
{
    class Registration
    {
        public static void RegistrationPage(int movieId, int[][] yourSeats, decimal totalPriceRoom, List<string> ordersList, decimal totalPriceOrder)
        {
            List<Movie> movies = Movie.Movies();

            string title = "Fill in your info.\n";
            string[] options = { "Payment", "Back" };
            Books mainMenu = new(title, options, movies[movieId].Age);
            (int selectedIndex, string[] information) = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Pay.PayPage(movieId, yourSeats, totalPriceRoom, ordersList, totalPriceOrder, information);
                    break;
                case 1:
                    Orders.OrdersPage(movieId, yourSeats, totalPriceRoom);
                    break;
            }
        }
    }
}