using Microsoft.AspNetCore.SignalR;
using StockQuoteAlertApp.Configuration;
using StockQuoteAlertApp.Hubs;
using StockQuoteAlertApp.Models;
using System.Net.Mail;
using System.Net;
using Newtonsoft.Json;
using StockQuoteAlertApp.DTO;
using StockQuoteAlertApp.Exception;

namespace StockQuoteAlertApp.Services
{
    public class MonitoringService
    {
        private readonly IConfiguration _configuration;
        private readonly IHubContext<MonitoringHub> _hubContext;
        private Timer _timer;
        public event EventHandler<System.Exception> ErrorOccurred;

        public MonitoringService(IConfiguration configuration, IHubContext<MonitoringHub> hubContext)
        {
            _configuration = configuration;
            _hubContext = hubContext;
        }

        public void StartMonitoring(Asset asset)
        {
            _timer = new Timer(async _ =>
            {
                try
                {
                    // Obter o preço atual do ativo.
                    decimal currentPrice = await GetCurrentPrice(asset.Symbol);

                    // Check buy and sell conditions
                    if (currentPrice < asset.BuyPrice)
                    {
                        // Envia email avisando que deve ser comprado.
                        await SendEmail("Buy", asset, currentPrice);
                    }
                    else if (currentPrice > asset.SellPrice)
                    {
                        // Envia email avisando que deve ser vendido.
                        await SendEmail("Sell", asset, currentPrice);
                    }

                    // Notificar clientes via SignalR
                    await _hubContext.Clients.All.SendAsync("UpdatePrice", asset.Symbol, currentPrice);
                }
                catch (System.Exception ex)
                {
                    ErrorOccurred?.Invoke(this, ex);
                }
            }, null, TimeSpan.Zero, TimeSpan.FromMinutes(1)); // Definição do intervalo de tempo.
        }


        private async Task<decimal> GetCurrentPrice(string symbol)
        {
            try
            {
                string url = $"https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol={symbol}&interval=1min&apikey=3A1CZFVC2R1W2WWW";

                using HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                ApiResponseDTO apiResponse = JsonConvert.DeserializeObject<ApiResponseDTO>(responseBody);

                if (apiResponse == null || apiResponse.Meta == null || apiResponse.TimeSeries == null || !apiResponse.TimeSeries.ContainsKey(apiResponse.Meta.LastRefreshed))
                {
                    throw new AssetException("This Asset doesn't exist or reached the Alpha Vantage API's call limit");
                }

                string lastRefreshedTime = apiResponse.Meta.LastRefreshed;
                return apiResponse.TimeSeries[lastRefreshedTime].Close;
            }
            catch (NullReferenceException)
            {
                // Capturando a NullReferenceException e lançando sua exceção personalizada.
                throw new AssetException("This Asset doesn't exist or reached the Alpha Vantage API's call limit");
            }
            catch (KeyNotFoundException)
            {
                // Capturando a KeyNotFoundException e lançando sua exceção personalizada.
                throw new AssetException("This Asset doesn't exist or reached the Alpha Vantage API's call limit");
            }
        }

        private async Task SendEmail(string action, Asset asset, decimal currentPrice)
        {
            var emailSettings = _configuration.GetSection("EmailSettings").Get<EmailSettings>();

            using SmtpClient client = new SmtpClient(emailSettings.MailServer, emailSettings.MailPort)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(emailSettings.Sender, emailSettings.Password),
                EnableSsl = true
            };

            string subject = $"{action} Advice - {asset.Symbol}";
            string body = $"The current price of {asset.Symbol} is {currentPrice}. Consider {action}.";

            var recipientEmails = emailSettings.RecipientEmails.Split(',').Select(e => e.Trim()).ToList();


            foreach (var recipient in recipientEmails)
            {
                using MailMessage mailMessage = new MailMessage(emailSettings.Sender, recipient, subject, body);
                await client.SendMailAsync(mailMessage);
            } 

        }

    }
}
