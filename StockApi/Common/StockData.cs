namespace Common;
public class StockData
{
    public string requestId { get; set; }

    public double _stockPrice { get; set; }

    public DateTime _timeStamp { get; set; }

    public StockData()
    {
    }

    public StockData(double stockPrice, DateTime timeStamp)
    {
        _stockPrice = stockPrice;
        _timeStamp = timeStamp;
    }

    public StockData(double stockPrice)
    {
        _stockPrice = stockPrice;
    }

}