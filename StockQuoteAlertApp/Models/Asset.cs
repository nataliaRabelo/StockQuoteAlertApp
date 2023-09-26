namespace StockQuoteAlertApp.Models
{
    /// <summary>
    /// Representa um ativo financeiro a ser monitorado.
    /// </summary>
    public class Asset
    {
        /// <summary>
        /// Obtém ou define o símbolo/sigla do ativo.
        /// </summary>
        public string Symbol { get; set; }
        /// <summary>
        /// Obtém ou define o preço de compra do ativo.
        /// </summary>
        public decimal BuyPrice { get; set; }
        /// <summary>
        /// Obtém ou define o preço de venda do ativo. Representa o valor no qual o usuário está interessado em vender.
        /// </summary>
        public decimal SellPrice { get; set; }
    }
}
