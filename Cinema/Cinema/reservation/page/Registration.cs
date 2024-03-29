﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.page
{
    class Registration
    {
        public static void RegistrationPage(int movieId, int timeId, int[][] yourSeats, decimal totalPriceRoom, List<string> ordersList, decimal totalPriceOrder)
        {
            List<Movie> movies = Movie.Movies();

            string title = "Fill in your info.\n";
            string[] options = { "Payment", "Back" };
            Books mainMenu = new(title, options, movies[movieId].Age);
            (int selectedIndex, string[] personalInfo) = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Pay.PayPage(movieId, timeId, yourSeats, totalPriceRoom, ordersList, totalPriceOrder, personalInfo);
                    break;
                case 1:
                    Orders.OrdersPage(movieId, timeId, yourSeats, totalPriceRoom);
                    break;
            }
        }
    }
}