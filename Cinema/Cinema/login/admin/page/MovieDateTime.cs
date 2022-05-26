using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using static System.Console;

namespace Cinema.page
{
    class MovieDateTime
    {
        public static void MovieDateTimePage(int movieId)
        {
            MoviesDateTime mainMenu = new(movieId);
            mainMenu.Run();
        }
    }
}
