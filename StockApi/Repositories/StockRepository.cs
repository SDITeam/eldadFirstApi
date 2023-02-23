using System.Net.Http.Json;
using System.Text.Json;
using System.Xml.Linq;

namespace Repositories
{
    public class StockRepository
    {
        private HttpClient _httpClient;
        private const string API_KEY = "a043a1a33c004b5d99536fd651636f1f";

        public StockRepository()
        {
            _httpClient = new HttpClient();
        }

        public async Task<double> GetStockPrice(string stockName)
        {
            string apiUrl = $"https://api.twelvedata.com/quote?symbol={stockName}&apikey={API_KEY}";
            var response = await _httpClient.GetFromJsonAsync<dynamic>(apiUrl);

            if (response.TryGetProperty("open", out JsonElement open))
            {
                return Convert.ToDouble(open.GetString());
            }

            throw new Exception("Action failed");    
        }
    }
}