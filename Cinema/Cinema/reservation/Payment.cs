using Cinema.page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Console;
using System.IO;
using System.Net.Mail;
using System.Net;


namespace Cinema
{
    class Payment
    {
        private int SelectedIndex;
        private int ReservationCode;
        private readonly string[] Options;
        private readonly string Prompt;
        private readonly int MovieId;
        private readonly int TimeId;
        private readonly int[][] YourSeats;
        private readonly decimal TotalPriceRoom;
        private readonly List<string> OrdersList;
        private readonly decimal TotalPriceOrder;
        private readonly string[] PersonalInfo;

        public static string JsonFileName() => Path.Combine("data/emailsnew");

        public Payment(string title, string[] options, int movieId, int timeId, int[][] yourSeats, decimal totalPriceRoom, List<string> ordersList, decimal totalPriceOrder, string[] Personalinfo)
        {
            Prompt = title;
            Options = options;
            SelectedIndex = 0;
            ReservationCode = 0;
            MovieId = movieId;
            TimeId = timeId;
            YourSeats = yourSeats;
            TotalPriceRoom = totalPriceRoom;
            OrdersList = ordersList;
            TotalPriceOrder = totalPriceOrder;
            PersonalInfo = Personalinfo;
        }
        
        public void Login()
        {
            Write("Gebruikersnaam: ");
            string? username = ReadLine();
            Write("Wachtwoord: ");
            var password = string.Empty;

            ConsoleKey key;
            do
            {
                var keyInfo = ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    Write("\b \b");
                    password = password[0..^1];
                }
                else if (key == ConsoleKey.Spacebar && password.Length > 0)
                {
                    Write("");
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Write("*");
                    password += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);

            Clear();
            WriteLine(Prompt);
            WriteLine($"Thank you for your reservation {username}. Your reservation had been succesfully received.\nYou will receive a confirmation e-mail within 10 minutes.\n");

            Random generator = new();
            ReservationCode = generator.Next(100000, 999999);

            int reservationCode = Reservation.ReservationsAdd(ReservationCode, MovieId, TimeId, YourSeats, TotalPriceRoom, OrdersList, TotalPriceOrder, PersonalInfo);
            Time.TimesChange(TimeId, YourSeats);
            WriteLine($"Your reservationcode is: {reservationCode}\n");
        }

        static async Task SendEmail(int reservationCode, int movieId, int timeId, int[][] yourSeats, decimal totalPriceRoom, List<string> ordersList, decimal totalPriceOrder, string[] personalInfo)
        {
            SmtpClient Client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = "tawanharinkextra@gmail.com",
                    Password = "TawanHarink123"
                }
            };
            MailAddress FromEmail = new MailAddress("hello@cinema.com", "Cinema");
            MailAddress ToEmail = new MailAddress("tawanharink@gmail.com", "Tawan");
            MailMessage Message = new MailMessage()
            {
                From = FromEmail,
                Subject = "Confirmation of reservation",
                Body = ($"Hello {personalInfo[0]},\n" +
                $" Thank you for your reservation. Here are the details of your reservation:\n" +
                $"{reservationCode}\n" +
                $"{movieId}\n" +
                $"{timeId}\n" +
                $"{yourSeats}\n" +
                $"{totalPriceRoom}\n" +
                $"{ordersList}\n" +
                $"{totalPriceOrder}\n" +
                $"{personalInfo}")
            };
            Message.To.Add(ToEmail);

            try
            {
                Client.Send(Message);
            }
            catch (Exception ex)
            {
                WriteLine(ex.ToString());
            }

            /*StringBuilder template = new();
            template.AppendLine("Dear @Model.FirstName,");
            template.AppendLine("<p>Thanks for purchasing @Model.ProductName. We hope you enjoy it.</p>");
            template.AppendLine("- The TimCo Team");

            Email.DefaultSender = sender;
            Email.DefaultRenderer = new RazorRenderer();

            var email = await Email
                .From("tim@timco.com")
                .To(personalInfo[1], personalInfo[0])
                .Subject("Thanks!")
                .UsingTemplate(template.ToString(), new { FirstName = personalInfo[0], ProductName = "Bacon-Wrapped Bacon" })
                //.Body("Thanks for buying our product.")
                .SendAsync();*/
        }

        private void Display()
        {
            WriteLine(Prompt);

            Login();

            SendEmail(ReservationCode, MovieId, TimeId, YourSeats, TotalPriceRoom, OrdersList, TotalPriceOrder, PersonalInfo);

            for (int i = 0; i < Options.Length; i++)
            {
                string currentOptions = Options[i];

                if (SelectedIndex == i) 
                { 
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;
                }
                else 
                {
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                }

                if (i == Options.Length - 1)
                {
                    WriteLine($" {currentOptions}");
                }
                else if (i == Options.Length - 2)
                {
                    WriteLine($"{i + 1}) {currentOptions}\n");
                }
                else
                {
                    WriteLine($"{i + 1}) {currentOptions}");
                }
                
            }
            ResetColor();
        }

        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Clear();
                Display();

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;

                    if(SelectedIndex < 0)
                    {
                        SelectedIndex = Options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;

                    if (SelectedIndex > Options.Length - 1)
                    {
                        SelectedIndex = 0;
                    }
                }
            }
            while (keyPressed != ConsoleKey.Enter);

            return SelectedIndex;
        }
    }
}
