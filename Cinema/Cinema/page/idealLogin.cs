using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Cinema.page
{
    class idealLogin
    {
        public static void idealLoginPage(string filmName)
        {
            string title = "Ideal Login Page\n";
            string[] options = {"Back"};
            
            paymentlogin mainMenu = new(title, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Ideal.IdealPage(filmName);
                    break;
            }
        }
    }
}
