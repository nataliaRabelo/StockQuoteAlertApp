namespace StockQuoteAlertApp.Models
{
    public class Asset
    {
        public string Symbol { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
    }
}
