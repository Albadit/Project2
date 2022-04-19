using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.page
{
    class loginScreen
    {
        public void loginScreenPage()
        {
            string title = "Please make an account.\n";
            string[] options = {"Back"};
            
            res mainMenu = new res(title, options);
            int selectedIndex = mainMenu.Run();

            

            switch (selectedIndex)
            {
                case 0:
                    chooseScreen mychooseScreen = new chooseScreen();
                    mychooseScreen.chooseScreenPage();
                    break;
            }
        }
    }
}
