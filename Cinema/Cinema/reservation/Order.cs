using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Cinema
{
    class Order
    {
        private int SelectedIndex;
        private readonly string[] Options;
        private readonly string Prompt;
        private List<Product> Orders;

        public Order(string title, string[] options, List<Product> order)
        {
            Prompt = title;
            Options = options;
            SelectedIndex = 0;
            Orders = order;
        }

        private void Display(List<string> ordersList, decimal totalPriceOrder)
        {
            WriteLine(Prompt);
            for (int i = 0; i < Options.Length; i++)
            {
                string currentOptions = Options[i];

                if (SelectedIndex == i) 
                { 
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;
                }
                else 
                {
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                }

                if (i == Options.Length - 1)
                {
                    WriteLine($" {currentOptions}");
                }
                else if (i == Options.Length - 2)
                {
                    WriteLine($"{i + 1}) {currentOptions}\n");
                }
                else
                {
                    WriteLine($"{i + 1}) {currentOptions}");
                }
                
            }
            ResetColor();

            foreach (var productsOrder in ordersList) Write($"\n{productsOrder}");

            string price = totalPriceOrder.ToString("0.00", CultureInfo.InvariantCulture);
            WriteLine($"\n\nTotal: {price}");
        }

        public (int, List<string>, decimal) Run()
        {
            List<string> ordersList = new();
            decimal totalPriceOrder = 0;

            ConsoleKey keyPressed;
            do
            {   
                Clear();
                Display(ordersList, totalPriceOrder);

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.A)
                {
                    int total = 1;
                    for (int i = 0; i < ordersList.Count; i++)
                    {
                        string num = string.Empty;
                        string product = string.Empty;
                        bool add = false;

                        foreach (var letter in ordersList[i])
                        {
                            if (Char.IsNumber(letter) && !add) num += letter;
                            if (add) product += letter;
                            if (letter == ' ') add = true;
                        }

                        if (product == Options[SelectedIndex])
                        {
                            total = Int32.Parse(num);
                            total++;
                            ordersList[i] = $"{total}x {Options[SelectedIndex]}";
                        }
                    }
                    if (total ==  1) ordersList.Add($"{total}x {Options[SelectedIndex]}");
                    totalPriceOrder += Orders[SelectedIndex].Price;
                    Display(ordersList, totalPriceOrder);
                }

                else if (keyPressed == ConsoleKey.D)
                {
                    for (int i = ordersList.Count - 1; i >= 0; i--)
                    {
                        string num = string.Empty;
                        string product = string.Empty;
                        bool add = false;

                        foreach (var letter in ordersList[i])
                        {
                            if (Char.IsNumber(letter) && !add) num += letter;
                            if (add) product += letter;
                            if (letter == ' ') add = true;
                        }

                        if (product == Options[SelectedIndex])
                        {
                            int total = Int32.Parse(num);
                            total--;
                            ordersList[i] = $"{total}x {Options[SelectedIndex]}";
                            if (total <= 0) ordersList.Remove(ordersList[i]);
                            if (totalPriceOrder > 0 && totalPriceOrder - Orders[SelectedIndex].Price >= 0) totalPriceOrder -= Orders[SelectedIndex].Price;
                        }
                    }
                    Display(ordersList, totalPriceOrder);
                }

                else if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;

                    if (SelectedIndex < 0)
                    {
                        SelectedIndex = Options.Length - 1;
                    }
                }

                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;

                    if (SelectedIndex > Options.Length - 1)
                    {
                        SelectedIndex = 0;
                    }
                }
            }
            while (keyPressed != ConsoleKey.Enter);
            
            return (SelectedIndex, ordersList, totalPriceOrder);
        }
    }
}
