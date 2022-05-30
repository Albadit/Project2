using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.page
{
    class RegisterMovie
    {
        public static void RegisterMoviePage()
        {
            string prompt = "Welcome Please select you reservation options.\n";
            RegisterMovies mainMenu = new(prompt);
            mainMenu.Run();
        }
    }
}
