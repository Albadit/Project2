using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Cinema.page
{
    class Film
    {
        public void FilmPage()
        {
            string prompt = "Choice your film\n";
            string[] options = { "Harry Potter", "Naruto", "Attack on Titan\n", "Back" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            
            if (selectedIndex == options.Length - 1)
            {
                Home myHome = new Home();
                myHome.HomePage();
            }
            else
            {
                string filmName = options[selectedIndex].Replace("\n", String.Empty);
                Seating mySeating = new Seating();
                mySeating.SeatingPage(filmName);
            }
            

            /* switch (selectedIndex)
             {
                 case 0:
                     WriteLine($"{options.IndexOf}");
                     break;
                 case 1:
                     WriteLine($"{options.Rank}");
                     break;
                 case 2:
                     break;
                 case 3:
                     Home myHome = new Home();
                     myHome.HomePage();
                     break;
             }*/
        }
    }
}
