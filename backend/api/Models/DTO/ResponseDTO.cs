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

    var quote = result.Indicators.Quote.FirstOrDefault() ?? throw new Exception("Could not get stock quote data");
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
      var date = datetime.ToString("yyyy-MM-dd");
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