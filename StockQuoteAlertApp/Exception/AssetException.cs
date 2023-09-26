namespace StockQuoteAlertApp.Exception
{
    /// <summary>
    /// Representa uma exceção específica relacionada a operações e validações de ativos financeiros.
    /// </summary>
    public class AssetException : NullReferenceException
    {
        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="AssetException"/> com uma mensagem de erro específica.
        /// </summary>
        /// <param name="message">A mensagem de erro que explica a razão da exceção.</param>
        public AssetException(string message) : base(message) { }

    }

}
