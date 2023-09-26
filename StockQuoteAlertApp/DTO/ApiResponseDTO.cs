using Newtonsoft.Json;

namespace StockQuoteAlertApp.DTO
{
    public class ApiResponseDTO
    {
        [JsonProperty("Meta Data")]
        public MetaDataDTO Meta { get; set; }

        [JsonProperty("Time Series (1min)")]
        public Dictionary<string, TimeSeriesEntryDTO> TimeSeries { get; set; }
    }
}
