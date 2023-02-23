namespace Common;
public class StockData
{
    public double stockPrice { get; set; }

    public DateTime timeStamp { get; set; }

    public string requestId { get; set; }

    public StockData(double stockPrice)
    {
        this.stockPrice = stockPrice;
    }
}