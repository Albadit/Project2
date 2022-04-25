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
        private string[] Options;
        private string Prompt;

        public Order(string title, string[] options)
        {
            Prompt = title;
            Options = options;
            SelectedIndex = 0;
        }

        public string Test()
        {
            Products myProducts = new Products();
            myProducts.Product();

            List<string> productSelect = new List<string>();
            List<string> orderList = Products.orderList;
            List<decimal> orderPriceList = Products.orderPriceList;
            int i = 0;

            foreach (var test in orderPriceList.ToArray())
            {
                if (SelectedIndex == i)
                {
                    Write(orderList[SelectedIndex]);
                }
                i++;
            }

            return orderList[SelectedIndex];
        }

        public decimal Testing()
        {
            List<decimal> orderPriceList = Products.orderPriceList;
            return orderPriceList[SelectedIndex];
        }

        private void Display(List<string> ress, decimal testing)
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

            foreach (var productsOrder in ress)
            {
                Write($"\n{productsOrder}");
            }

            string price = testing.ToString("0.00", CultureInfo.InvariantCulture);
            Write($"\n\nTotal: {price}");
        }

        public int Run()
        {
            List<string> ress = new List<string>();
            decimal testing = 0;

            ConsoleKey keyPressed;
            do
            {   
                Clear();
                Display(ress, testing);

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
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

                if (keyPressed == ConsoleKey.A)
                {
                    ress.Add(Test());
                    testing += Testing();
                    Display(ress, testing);
                }
            }
            while (keyPressed != ConsoleKey.Enter);
            
            return SelectedIndex;
        }
    }
}
