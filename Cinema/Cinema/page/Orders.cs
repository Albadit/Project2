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
            List<string> orderList = Products.orderList;
            orderList.Clear();

            Products myOrder = new Products();
            myOrder.Product();
            orderList.Add("Back");

            string title = "Choice your product\n";
            string[] options = orderList.ToArray();
            OrderFunctie mainMenu = new OrderFunctie(title, options);
            int selectedIndex = mainMenu.Run();

            if (selectedIndex == options.Length - 1)
            {
                Home myHome = new Home();
                myHome.HomePage();
            }
        }
    }
}
