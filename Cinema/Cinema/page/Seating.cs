using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.page
{
    class Seating
    {
        public void SeatingPage(string filmName)
        {
            string prompt = $"Choice your seat for the film {filmName}\n";
            string[] options = { "test", "blayt", "kanker\n", "Back" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    Film myFilm = new Film();
                    myFilm.FilmPage();
                    break;
            }
        }


    }
}
