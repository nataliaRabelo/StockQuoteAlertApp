using Newtonsoft.Json;

namespace StockQuoteAlertApp.DTO
{
    /// <summary>
    /// Representa a resposta da API que fornece informações de cotação de ativos.
    /// </summary>
    public class ApiResponseDTO
    {
        /// <summary>
        /// Obtém ou define os metadados associados à cotação do ativo.
        /// </summary>
        /// <value>
        /// Uma instância da classe <see cref="MetaDataDTO"/> que contém os metadados.
        /// </value>
        [JsonProperty("Meta Data")]
        public MetaDataDTO Meta { get; set; }

        /// <summary>
        /// Obtém ou define a série temporal relacionada à cotação do ativo.
        /// </summary>
        /// <value>
        /// Um dicionário cuja chave é uma string representando o timestamp e o valor é uma instância da classe <see cref="TimeSeriesEntryDTO"/> que contém a informação da cotação.
        /// </value>
        [JsonProperty("Time Series (1min)")]
        public Dictionary<string, TimeSeriesEntryDTO> TimeSeries { get; set; }
    }
}
