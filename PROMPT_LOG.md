# Prompts

`
var builder = WebApplication.CreateBuilder(args); // Add services to the container. // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi builder.Services.AddOpenApi(); builder.Services.AddControllers(); var app = builder.Build(); // Configure the HTTP request pipeline. if (app.Environment.IsDevelopment()) { app.MapOpenApi(); } app.UseHttpsRedirection(); app.MapControllers(); app.Run(); Please insert the configurations necessary for swagger
`
### Why
### Keep Change Reject
### Manual Changes


`
Unhandled exception. System.Reflection.ReflectionTypeLoadException: Unable to load one or more of the requested types. Could not load type 'Microsoft.OpenApi.Any.IOpenApiAny' from assembly 'Microsoft.OpenApi, Version=2.7.5.0, Culture=neutral, PublicKeyToken=3f5743946376f042'.
`

### Why
### Keep Change Reject
### Manual Changes

`
public class StockController : ControllerBase { private HttpClient StockHttpClient = new() { BaseAddress = new Uri("https://query1.finance.yahoo.com/v8/finance/chart/") }; // GET: api/stocks/{symbol} [HttpGet("{symbol}")] public async Task<int> GetStockBySymbol(String symbol) { using HttpResponseMessage response = await StockHttpClient.GetAsync(symbol); response.EnsureSuccessStatusCode(); var JsonResponse = await response.Content.ReadAsStringAsync(); Console.WriteLine(JsonResponse); return 0; } } 

How should I structure an http get request to another site? As I test, I get a too many requests code from the request
`