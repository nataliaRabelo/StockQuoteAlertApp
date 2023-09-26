namespace StockQuoteAlertApp.Exception
{
    public class AssetException : NullReferenceException
    {
        public AssetException() : base() { }
        public AssetException(string message) : base(message) { }
        public AssetException(string message, System.Exception inner) : base(message, inner) { }
    }

}
