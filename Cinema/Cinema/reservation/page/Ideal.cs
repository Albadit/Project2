﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.page
{
    class Ideal
    {
        public static void IdealPage(int movieId, int timeId, int[][] yourSeats, decimal totalPriceRoom, List<string> ordersList, decimal totalPriceOrder, string[] personalInfo)
        {
            string title = "Choose your bank:\n";
            string[] options = { "ABN AMRO", "ASN Bank", "bunq", "ING", "Knab", "Rabobank", "RegioBank", "Revolut", "SNS", "Svenska Handelsbanken", "Triodos Bank", "Van Lanschot", "Back"};
            Menu mainMenu = new(title, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case < 12:
                    BankLogin.BankLoginPage(movieId, timeId, yourSeats, totalPriceRoom, ordersList, totalPriceOrder, personalInfo);
                    break;
                case 12:
                    Pay.PayPage(movieId, timeId, yourSeats, totalPriceRoom, ordersList, totalPriceOrder, personalInfo);
                    break;
            }
        }
    }
}
