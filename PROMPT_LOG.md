# Prompts

`
var builder = WebApplication.CreateBuilder(args); // Add services to the container. // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi builder.Services.AddOpenApi(); builder.Services.AddControllers(); var app = builder.Build(); // Configure the HTTP request pipeline. if (app.Environment.IsDevelopment()) { app.MapOpenApi(); } app.UseHttpsRedirection(); app.MapControllers(); app.Run(); Please insert the configurations necessary for swagger
`
### Why
Chatbots are usually quick with simple configurations it seemed like it wold be faster to have the AI give me the necessary config.
### Keep Change Reject
I implemented the lines given to start Swagger in program.cs
### Manual Changes
N/A

`
Unhandled exception. System.Reflection.ReflectionTypeLoadException: Unable to load one or more of the requested types. Could not load type 'Microsoft.OpenApi.Any.IOpenApiAny' from assembly 'Microsoft.OpenApi, Version=2.7.5.0, Culture=neutral, PublicKeyToken=3f5743946376f042'.
`

### Why
Chatbots are great with identifying errors and providing quick fixes that searches might sometimes require more in depth work to get to.
### Keep Change Reject
It suggested that it may have been a version mismatch, and to simply remove Swagger in favor of OpenAPI. However, the GUI of Swagger makes testing easy and I'm familiar with it so I decided to try downgrading my Swagger package. I did install dotnet several months ago, so the mismatch was likely after I installed the newest Swagger package.
### Manual Changes
Manual downgrade

```
public class StockController : ControllerBase { private HttpClient StockHttpClient = new() { BaseAddress = new Uri("https://query1.finance.yahoo.com/v8/finance/chart/") }; // GET: api/stocks/{symbol} [HttpGet("{symbol}")] public async Task<int> GetStockBySymbol(String symbol) { using HttpResponseMessage response = await StockHttpClient.GetAsync(symbol); response.EnsureSuccessStatusCode(); var JsonResponse = await response.Content.ReadAsStringAsync(); Console.WriteLine(JsonResponse); return 0; } } 

How should I structure an http get request to another site? As I test, I get a too many requests code from the request
```
### Why
Again, debugging is quick with chatbots. It was also helpful to get a reference of sending API requests
### Keep Change Reject
The Chatbot suggested that I use the HTTPClient to make the requests and that the API calls may have been rejected due to a missing user-agent header. I implemented the code it suggested because the missing header made sense considering the curl request with it worked.
### Manual Changes
Integrating the HttpClient into the class

```
  An unhandled exception has occurred while executing the request.
      Swashbuckle.AspNetCore.SwaggerGen.SwaggerGeneratorException: Conflicting method/path combination "GET api/stocks/{symbol}" for actions - api.Controllers.StockController.GetStockBySymbol (api),api.Controllers.StockController.GetStockBySymbol (api). Actions require a unique method/path combination for Swagger/OpenAPI 3.0. Use ConflictingActionsResolver as a workaround
```
### Why
Quick debugging
### Keep Change Reject
Although it suggested that I had duplicated an api endpoint, I knew this was not the case. It also suggested to run dotnet clean to clear build artifacts, fixing the bug
### Manual Changes
N/A

`How can you work with and convert a json response into an object`
### Why
I wanted some examples of 
### Keep Change Reject
I worked off of the given examples and used the classes it generated from the nested properties of Yahoo's api response.
### Manual Changes
N/A

```
"timestamp": [1780666200, 1780667100, 1780668000, 1780668900, 1780669800, 1780670700, 1780671600, 1780672500, 1780673400, 1780674300, 1780675200, 1780676100, 1780677000, 1780677900, 1780678800, 1780679700, 1780680600, 1780681500, 1780682400, 1780683300, 1780684200, 1780685100, 1780686000, 1780686900, 1780687800, 1780688700, 1780689600],
        "indicators": {
          "quote": [
            {
              "high": [424.679901123047, 414.369995117188, 411.5, 410.399993896484, 408.826385498047, 406.891998291016, 405.989990234375, 403.229888916016, 403.178009033203, 402.269012451172, 401.480010986328, 400.299987792969, 399.149993896484, 397.769989013672, 397.779998779297, 396.600006103516, 397.200012207031, 396.279998779297, 396.200012207031, 393.820098876953, 392.529907226563, 392.470001220703, 392.079986572266, 391.630004882813, 391.920013427734, 393.489990234375, 391],
              "volume": [5924042, 3288625, 2285981, 2320077, 1840515, 1557494, 2707895, 1791458, 1869539, 1283022, 2175050, 1761686, 1920253, 1785898, 1671198, 1787270, 1531582, 1051467, 1670368, 1789360, 1701888, 1650285, 2145136, 2207363, 2283839, 3984796, 0],
              "close": [413.790008544922, 409.651306152344, 409.519989013672, 406.709991455078, 406.420013427734, 405.390014648438, 401.904998779297, 402.690002441406, 401.230010986328, 401.329986572266, 399.190002441406, 399.004699707031, 397.015014648438, 397.730010986328, 395.820007324219, 395.489990234375, 395.309997558594, 396.160003662109, 393.790008544922, 391.670013427734, 391.765014648438, 391.769989013672, 389.589904785156, 391.609893798828, 391.860107421875, 390.970001220703, 391],
              "open": [420.545013427734, 413.429992675781, 409.709991455078, 409.489990234375, 406.640014648438, 406.4580078125, 405.424987792969, 401.910095214844, 402.660003662109, 401.239990234375, 401.369995117188, 399.200012207031, 399, 396.980010986328, 397.730010986328, 395.809997558594, 395.509613037109, 395.350006103516, 396.160003662109, 393.820007324219, 391.635009765625, 391.690002441406, 391.709991455078, 389.489990234375, 391.570007324219, 391.859985351563, 391],
              "low": [413.399993896484, 409.651000976563, 408.330108642578, 405.450012207031, 405.859985351563, 405.190002441406, 401.859985351563, 401.739990234375, 400.440002441406, 400.560089111328, 399.109985351563, 398.559997558594, 396.740112304688, 396.089996337891, 395.140014648438, 394.899993896484, 394.899993896484, 395.049987792969, 393.149993896484, 391.410003662109, 390.929992675781, 390.670013427734, 389.160003662109, 388.589996337891, 389.570098876953, 390.399993896484, 391]
            }
          ]
        }

Are stock timestamps given in seconds?
```
### Why
I needed to know what sort of data the timestamps were stored as and how to convert it to datetime, which a chatbot's broad knowledge would know.
### Keep Change Reject
I learned that they were stored in unix seconds and used the DateTime conversion method given to convert them into DateTimeOffset objects
### Manual Changes
Then I used those objects to DateTime format the objects into the desired "yyyy-MM-dd" style

```
https://query1.finance.yahoo.com/v8/finance/chart/TSLA?interval=1d
Does their api allow me to query the past month or range of dates at once?
```
### Why
I realized that the url's query parameters made it likely that there existed some to get data day by day for a month, making the data easier to parse.
### Keep Change Reject
It suggested the range and interval parameters, which I changed to 1d and 1mo
### Manual Changes
Query parameter addition to request url

```
namespace api.Models.DTO;

public class YahooResponse
{
    public Chart Chart { get; set; } = new();
}

public class Chart
{
    public List<Result> Result { get; set; } = [];
}

public class Result
{
    public Meta Meta { get; set; } = new();
    public Indicator Indicator { get; set; } = new();
    public List<long> Timestamp {get; set;} = [];
}

public class Meta
{
    public string Symbol { get; set; } = "";
}

public class Indicator
{
    public List<Quote> Quote = [];
}

public class Quote
{
    public Data Data = new();
}

public class Data
{
    public List<decimal>? High;
    public List<long>? Volume;
    public List<decimal>? Close;
    public List<decimal>? Open;
    public List<decimal>? Low;
}

Are these DTOs best practice?
```
### Why
It's always good to double check if what you're doing is the best way to do things
### Keep Change Reject
It saw that I had accidentally been mixing fields and properties, which I went back and fixed. Although it suggested that I instantiate the lists with new(), I rejected those changes since [] is equivalent
### Manual Changes
N/A

```
namespace api.Models.DTO;
public class ResponseDTO
{
  public required string symbol;
  public List<DayData> data = [];
  public ResponseDTO(YahooResponse yahooResponse)
  {
    Result? result = yahooResponse.Chart.Result.FirstOrDefault();
    if (result != null)
    {
      symbol = result.Meta.Symbol;
    } else
    {
      throw new Exception("Stock symbol not found.");
    }

    var quote = result.Indicator.Quote.FirstOrDefault() ?? throw new Exception("Could not get stock quote data");
    var highs = quote.High;
    var lows = quote.Low;
    var open = quote.Open;
    var close = quote.Close;
    var volume = quote.Volume;

    var timestamps = result.Timestamp;
    int len = timestamps.Count;
    
    for (int i = 0; i < len; i++)
    {
      var datetime = DateTimeOffset.FromUnixTimeSeconds(timestamps[i]);
      var date = datetime.ToString("YYYY-MM-DD");
      data.Add(new DayData
      {
        Date = date,
        High = highs[i],
        Low = lows[i],
        Open = open[i],
        Close = close[i],
        Volume = volume[i]
      });
    }

  }
}

This is a lot of logic in a class, is it worth extrapolating to a service class?
```
### Why
Having too much business logic in a model class is usually a bad idea. It was worth getting a second opinion on committing to a service class.
### Keep Change Reject
It agreed with the suggestion and I refactored the logic into a new Mapper class.
### Manual Changes
Refactoring

```
return new ResponseDTO
        {
            Symbol = result.Meta.Symbol,
            Data = data
        };

Why is this constructor in the mapper returning an empty object? Symbol and data are populated correctly
```
### Why
Debugging
### Keep Change Reject
It found that once again, I had used fields instead of properties resulting in the object's properties not being set properly.
### Manual Changes
Refactoring

```
I'm building the frontend for my backend api now. I have a StockInput and StockViewer component. How can I fetch the api and display it?
```
### Why
Quick reference on Api usage
### Keep Change Reject
I kept the suggested api calling code, but modified it to the correct port.
### Manual Changes
App.jsx structure setup and Component structures

```
Give me some CSS for each of the components
```
### Why
Quick styling
### Keep Change Reject
Kept much of the suggested css, but did tweak some spacing and colors for better readability
### Manual Changes
Color/spacing

```
Please add some basic error checking
```
### Why
Generating some quick checking for time purposes. After, I double checked to ensure that it worked.
### Keep Change Reject
I kept the suggested code, but later tweaked the message to be generic message rather than a long status message
### Manual Changes
N/A