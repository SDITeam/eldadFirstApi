using Common;
using Repositories;

namespace Services
{
    public class StockService
    {
        private readonly StockRepository _stockRepository;

        public StockService()
        {
            _stockRepository = new StockRepository();
        }

        public async Task<StockData> GetStockData(string symbol)
        {
            double stockPrice = await _stockRepository.GetStockPrice(symbol);

            StockData stockData = new StockData(stockPrice);
            stockData.timeStamp = DateTime.Now;

            return stockData;
        }
    }
}