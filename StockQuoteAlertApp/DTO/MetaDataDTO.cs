using Newtonsoft.Json;

namespace StockQuoteAlertApp.DTO
{
    public class MetaDataDTO
    {
        [JsonProperty("3. Last Refreshed")]
        public string LastRefreshed { get; set; }
    }
}
