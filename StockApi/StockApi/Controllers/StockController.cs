using Common;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Runtime.CompilerServices;

namespace StockApi.Controllers
{
    [ApiController]
    [Route("/stocks")]
    public class StockController : ControllerBase
    {
        private readonly ILogger<StockController> _logger;
        private readonly StockService _stockService;

        public StockController(ILogger<StockController> logger)
        {
            _logger = logger;
            _stockService = new StockService();
        }

        [HttpGet("{stockName}/price", Name = "GetStockProce")]
        public async Task<IActionResult> Get(string stockName)
        {
            var requestId = $"stocks-{Guid.NewGuid().ToString()}";

            try
            {
                _logger.LogInformation($"requestId={requestId} ; get stock price for {stockName}");

                StockData stockData = await _stockService.GetStockData(stockName);
                stockData.requestId = requestId;

                _logger.LogInformation(
                    $"requestId={requestId} ; successfully got stock price for {stockName}");

                return Ok(stockData);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"requestId={requestId}, {exception.Message}");
             
                return BadRequest(exception.Message);
            }
        }
    }
}