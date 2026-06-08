using System.Threading.Tasks;
using api.Models.DTO;
using api.Models.Mapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
  
  [Route("api/stocks")]
  [ApiController]
  public class StockController : ControllerBase
  {
    /** The Http client for querying the stock API */
    private readonly HttpClient _httpClient;

    private readonly ResponseMapper _responseMapper;
    /**
    * Queries Yahoo's stock API and adds a required user-agent header
    */
    public StockController(IHttpClientFactory factory, ResponseMapper responseMapper)
    {
      _httpClient = factory.CreateClient();
      _httpClient.BaseAddress =
        new Uri("https://query1.finance.yahoo.com/v8/finance/chart/");
      _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(
        "Mozilla/5.0 (Windows NT 10.0; Win64; x64)"
      );
      _responseMapper = responseMapper;
    }

    // GET: api/stocks/{symbol}
    /**
    * Takes in a stock symbol, queries Yahoo's API,
    * then converts it to a ResponseDTO to return
    */
    [HttpGet("{symbol}")]
    public async Task<IActionResult> GetStockBySymbol(string symbol)
    {
      // Add query parameters to query by day for 1 month
      using HttpResponseMessage response = await _httpClient.GetAsync(symbol + "?range=1mo&interval=1d");

      // Check if request failed
      if (!response.IsSuccessStatusCode)
      {
        return StatusCode(
          (int)response.StatusCode,
          await response.Content.ReadAsStringAsync()
        );
      }

      // Request succeeded
      var JsonResponse = await response.Content.ReadAsStringAsync();

      var yahooResponse = await response.Content.ReadFromJsonAsync<YahooResponse>();

      // var symbolResponse = yahooResponse?.Chart?.Result?.FirstOrDefault()?.Meta?.Symbol;
      var responseDto = yahooResponse != null 
        ? _responseMapper.Map(yahooResponse) 
        : throw new Exception("Could not parse the api response");

      return Ok(responseDto);
    }
  }
}
