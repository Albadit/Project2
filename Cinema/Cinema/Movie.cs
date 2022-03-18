using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using static System.Console;

namespace Cinema
{
    class Movie
    {
        public int Id { get; set; } = 0;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string CreditcardNumber { get; set; } = string.Empty;

        public static string JsonFileName() => Path.Combine("data", "accounts.json");

        public static List<Movie> ReadAll()
        {
            string json = File.ReadAllText(JsonFileName());
            return JsonSerializer.Deserialize<List<Movie>>(json) ?? new List<Movie>();
        }

        public static void WriteAll(List<Movie> accounts)
        {
            string json = JsonSerializer.Serialize(accounts);
            File.WriteAllText(JsonFileName(), json);
        }
        public void Movies()
        {
            var accounts = Movie.ReadAll();
            foreach (var account in accounts)
            {
                WriteLine($"{account.Id} {account.Email}\n");
                account.Password = $"reset-{account.Id}";
            }
            Movie.WriteAll(accounts);
        }
    }
}
