using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.page
{
    class idealLogin
    {
        public void idealLoginPage(string filmName)
        {
            string title = "Ideal Login Page\n";
            string[] options = {"Back"};
            
            paymentlogin mainMenu = new paymentlogin(title, options);
            int selectedIndex = mainMenu.Run();

            

            switch (selectedIndex)
            {
                case 0:
                    Ideal myIdeal = new Ideal();
                    myIdeal.IdealPage(filmName);
                    break;
            }
        }
    }
}
