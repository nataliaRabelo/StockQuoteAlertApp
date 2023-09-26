using Newtonsoft.Json;

namespace StockQuoteAlertApp.DTO
{
    /// <summary>
    /// Representa uma entrada de série temporal associada à cotação de um ativo.
    /// </summary>
    public class TimeSeriesEntryDTO
    {
        /// <summary>
        /// Obtém ou define o valor de fechamento da cotação para a entrada da série temporal.
        /// </summary>
        /// <value>
        /// O valor de fechamento da cotação.
        /// </value>
        [JsonProperty("4. close")]
        public decimal Close { get; set; }
    }
}
