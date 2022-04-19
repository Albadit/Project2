using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using static System.Console;

namespace Cinema.page
{
    class Order
    {
        public void OrdersPage()
        {
            List<string> filmList = Products.orderList;
            filmList.Clear();

            Products myOrder = new Products();
            myOrder.Product();
            filmList.Add("Back");

            string title = "Choice your film\n";
            string[] options = filmList.ToArray();
            Menu mainMenu = new Menu(title, options);
            int selectedIndex = mainMenu.Run();

            if (selectedIndex == options.Length - 1)
            {
                Home myHome = new Home();
                myHome.HomePage();
            }
        }
    }
}
