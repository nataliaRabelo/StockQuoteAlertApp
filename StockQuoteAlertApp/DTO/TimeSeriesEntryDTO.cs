using Newtonsoft.Json;

namespace StockQuoteAlertApp.DTO
{
    public class TimeSeriesEntryDTO
    {
        [JsonProperty("4. close")]
        public decimal Close { get; set; }
    }
}
