using System.Text.Json;

namespace JsonReader
{
    public class Account
    {
        public int Id { get; set; } = 0;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string CreditcardNumber { get; set; } = string.Empty;

        public static string JsonFileName() => Path.Combine("data", "accounts.json");

        public static List<Account> ReadAll()
        {
            string json = File.ReadAllText(JsonFileName());
            return JsonSerializer.Deserialize<List<Account>>(json) ?? new List<Account>();
        }

        public static void WriteAll(List<Account> accounts)
        {
            string json = JsonSerializer.Serialize(accounts);
            File.WriteAllText(JsonFileName(), json);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var accounts = Account.ReadAll();
            foreach (var account in accounts)
            {
                Console.WriteLine($"{account.Id} {account.Email}\n");
                account.Password = $"reset-{account.Id}";
            }
            Account.WriteAll(accounts);
        }
    }
}