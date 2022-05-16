using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using static System.Console;
using System.Globalization;

namespace Cinema
{
    class Email
    {
        
        public static string Emails(int reservationCode, int movieId, int timeId, int[][] yourSeats, decimal totalPriceRoom, List<string> ordersList, decimal totalPriceOrder, string[] personalInfo)
        {
            List<Movie> movies = Movie.Movies();
            List<Time> times = Time.Times();
            string text = string.Empty;

            int hour = times[timeId].Start[0] * 60;
            double minutes = hour + times[timeId].Start[1] + times[timeId].Duration;
            double minute = minutes / 60;
            hour = (int)(minutes / 60);
            int min = (int)((minute - (int)minute) * 60);
            string time = $"{times[timeId].Start[0]}:{times[timeId].Start[1]} - {hour}:{min}";

            string date = DateTime.Now.ToString("d MMMM yyyy");

            string priceRoom = totalPriceRoom.ToString("0.00", CultureInfo.InvariantCulture);
            string priceOrder = totalPriceOrder.ToString("0.00", CultureInfo.InvariantCulture);
            decimal price = totalPriceRoom + totalPriceOrder;
            string totalPrice = price.ToString("0.00", CultureInfo.InvariantCulture);

            text += @"<!DOCTYPE html>
            <html lang='en' xmlns:v='urn:schemas-microsoft-com:vml' xmlns:o='urn:schemas-microsoft-com:office:office'>
            <head>
              <meta charset='utf8'>
              <meta http-equiv='x-ua-compatible' content='ie=edge'>
              <meta name='viewport' content='width=device-width,initial-scale=1'>
              <meta name='x-apple-disable-message-reformatting'>
              <title>Your reservation is now confirmed</title>
              <link href='https://fonts.googleapis.com/css?family=Roboto' rel='stylesheet'>
              <style>
                @media screen {
                  img { max-width: 100%; }
                  td, th { box-sizing: border-box; }
                  u ~ div .wrapper { min-width: 100vw;}
                  a[x-apple-data-detectors] { color: inherit; text-decoration: none; }
                  .all-font-roboto { font-family: Roboto, -apple-system, 'Segoe UI', sans-serif !important; }
                  .all-font-sans { font-family: -apple-system, 'Segoe UI', sans-serif !important; }
                  .sm-inline-block { display: inline-block !important; }
                  .sm-hidden { display: none !important; }
                  .sm-leading-32 { line-height: 32px !important; }
                  .sm-p-20 { padding: 20px !important; }
                  .sm-py-12 { padding-top: 12px !important; padding-bottom: 12px !important;}
                  .sm-text-center { text-align: center !important; }
                  .sm-text-xs { font-size: 12px !important; }
                  .sm-text-lg { font-size: 18px !important; }
                  .sm-w-1-4 { width: 25% !important; }
                  .sm-w-3-4 { width: 75% !important; }
                  .sm-w-full { width: 100% !important; }
                  .sm-dui17-b-t { border: solid #FF4949; border-width: 4px 0 0; }
                }
              </style>
            </head>
            <body style='box-sizing: border-box; margin: 0; padding: 0; width: 100%; word-break: break-word; -webkit-font-smoothing: antialiased; background-color: #ebebeb;'>
              <table class='wrapper all-font-sans' width='100%' height='100%' cellpadding='0' cellspacing='0' role='presentation'>
                <tr>
                  <td align='center' style='padding: 24px;' width='100%'>
                    <table max-width='600px' cellpadding='0' cellspacing='0' role='presentation'>
                      <tr>
                        <td colspan='2' class='sm-inline-block'>
                          <img src='https://browsecat.net/sites/default/files/styles/480x272/public/cinema-wallpapers-103255-874630-3746199.png?itok=QuQ9nzHs' alt='Double Room' style='border: 0; line-height: 100%; vertical-align: middle; border-top-left-radius: 4px; border-top-right-radius: 4px; box-shadow: 0 10px 15px -3px rgba(0, 0, 0, .1), 0 4px 6px -2px rgba(0, 0, 0, .05);'>
                        </td>
                      </tr>
                      <tr>
                        <td align='left' class='sm-p-20 sm-dui17-b-t' style='border-radius: 2px; padding: 40px; position: relative; box-shadow: 0 10px 15px -3px rgba(0, 0, 0, .1), 0 4px 6px -2px rgba(0, 0, 0, .05); vertical-align: top; z-index: 50;' bgcolor='#ffffff' valign='top'>
                          <table width='100%' cellpadding='0' cellspacing='0' role='presentation'>
                            <tr>
                              <td width='80%'>
                                <h1 class='sm-text-lg all-font-roboto' style='color: black; font-weight: 700; line-height: 100%; margin: 0; margin-bottom: 4px; font-size: 24px;'>Movie reservation</h1>
                                <p class='sm-text-xs' style='margin: 0; color: #a0aec0; font-size: 14px;'>Your reservation is now confirmed</p>
                              </td>
                            </tr>
                          </table>
                          <div style='line-height: 32px;'>&zwnj;</div>
                          <table class='sm-leading-32' style='line-height: 28px; font-size: 14px;' width='100%' cellpadding='0' cellspacing='0' role='presentation'>
                            <tr>
                              <td class='sm-inline-block' style='color: #718096;'>Reservation Code</td>";
                    text += $"<td class='sm-inline-block' style='font-weight: 600; float: right; color: black;' align='right'>{reservationCode}</td>";
                  text += @"</tr>
                            <tr>
                              <td class='sm-inline-block' style='color: #718096;'>Movie</td>";
                    text += $"<td class='sm-inline-block' style='font-weight: 600; float: right; color: black;' align='right'>{movies[movieId].Name}</td>";
                  text += @"</tr>
                            <tr>
                              <td class='sm-w-1-4 sm-inline-block' style='color: #718096;'>Time</td>";
                    text += $"<td class='sm-w-3-4 sm-inline-block' style='font-weight: 600; float: right;color: black;' align='right'>{time}</td>";
                  text += @"</tr>
                          </table>
                          <table width='100%' cellpadding='0' cellspacing='0' role='presentation'>
                            <tr>
                              <td style='padding-top: 24px; padding-bottom: 24px;'>
                                <div style='background-color: #edf2f7; height: 2px; line-height: 2px;'>&zwnj;</div>
                              </td>
                            </tr>
                          </table>
                          <table style='font-size: 14px;' width='100%' cellpadding='0' cellspacing='0' role='presentation'>
                            <tr>
                              <td class='sm-w-full sm-inline-block sm-text-center' width='40%'>
                                <p class='all-font-roboto' style='margin: 0; margin-bottom: 4px; color: #a0aec0; font-size: 10px; text-transform: uppercase; letter-spacing: 1px;'>Date</p>";
                      text += $"<p class='all-font-roboto' style='font-weight: 600; margin: 0; color: black;'>{date}</p>";
                    text += @"</td>
                            </tr>
                          </table>
                          <table width='100%' cellpadding='0' cellspacing='0' role='presentation'>
                            <tr>
                              <td style='padding-top: 24px; padding-bottom: 24px;'>
                                <div style='background-color: #edf2f7; height: 2px; line-height: 2px;'>&zwnj;</div>
                              </td>
                            </tr>
                          </table>
                          <table style='line-height: 28px; font-size: 14px;' width='100%' cellpadding='0' cellspacing='0' role='presentation'>
                            <tr>
                              <td style='color: #718096;' >Seats price</td>";
                    text += $"<td style='font-weight: 600; float: right; color: black;' align='right'>€{priceRoom}</td>";
                  text += @"</tr>
                            <tr>
                              <td style='color: #718096;' >Orders price</td>";
                    text += $"<td style='font-weight: 600; float: right; color: black;' align='right'>€{priceOrder}</td>";
                  text += @"</tr>
                            <tr>
                              <td style='font-weight: 600; padding-top: 32px; color: black; font-size: 20px;' >Total</td>";
                    text += $"<td style='font-weight: 600; padding-top: 32px; float: right; color: #68d391; font-size: 20px;' align='right'>€{totalPrice}</td>";
                  text += @"</tr>
                          </table>
                        </td>
                      </tr>
                    </table>
                  </td>
                </tr>
              </table>
            </body>
            </html>";
            return text;
        }
    }
}
