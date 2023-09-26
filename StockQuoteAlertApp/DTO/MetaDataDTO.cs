using Newtonsoft.Json;

namespace StockQuoteAlertApp.DTO
{
    /// <summary>
    /// Representa a data e hora da última atualização dos metadados associados à cotação de um ativo.
    /// </summary>
    public class MetaDataDTO
    {
        /// <summary>
        /// Obtém ou define a data e hora da última atualização dos metadados.
        /// </summary>
        /// <value>
        /// A data e hora no formato string da última atualização.
        /// </value>
        [JsonProperty("3. Last Refreshed")]
        public string LastRefreshed { get; set; }
    }
}
