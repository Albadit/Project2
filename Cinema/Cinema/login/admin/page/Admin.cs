using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.page
{
    class Admin
    {
        public static void AdminPage()
        {
            string Prompt = "Please fill in your username and password.\n";
            AdminLogin mainMenu = new(Prompt);
            mainMenu.Run();
        }
    }
}
