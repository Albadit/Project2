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

        public Order(string title, string[] options)
        {
            Prompt = title;
            Options = options;
            SelectedIndex = 0;
        }

        private void Display(List<string> check, decimal totalPrice)
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

            foreach (var productsOrder in check)
            {
                Write($"\n{productsOrder}");
            }

            string price = totalPrice.ToString("0.00", CultureInfo.InvariantCulture);
            Write($"\n\nTotal: {price}");

        }

        public int Run()
        {
            List<decimal> orderPriceList = Product.OrderPrice();
            List<string> check = new();
            decimal totalPrice = 0;

            ConsoleKey keyPressed;
            do
            {   
                Clear();
                Display(check, totalPrice);

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.A)
                {
                    check.Add(Options[SelectedIndex]);
                    totalPrice += orderPriceList[SelectedIndex];
                    Display(check, totalPrice);
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
            
            return SelectedIndex;
        }
    }
}
