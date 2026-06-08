namespace api.Models.Mapper;

using api.Models;
using api.Models.DTO;

public class ResponseMapper
{
  /**
  * Maps a Yahoo response to a ResponseDTO
  */
    public ResponseDTO Map(YahooResponse yahooResponse)
    {
        var result = yahooResponse.Chart.Result.FirstOrDefault()
            ?? throw new Exception("Stock symbol not found.");

        var quote = result.Indicators.Quote.FirstOrDefault()
            ?? throw new Exception("Could not get stock quote data");

        var highs = quote.High;
        var lows = quote.Low;
        var open = quote.Open;
        var close = quote.Close;
        var volume = quote.Volume;
        var timestamps = result.Timestamp;

        var data = new List<DayData>();

        // Iterate through all lists and form a DayData object
        for (int i = 0; i < timestamps.Count; i++)
        {
            var date = DateTimeOffset
                .FromUnixTimeSeconds(timestamps[i])
                .ToString("yyyy-MM-dd");

            data.Add(new DayData
            {
                Date = date,
                High = Round(highs[i]),
                Low = Round(lows[i]),
                Open = Round(open[i]),
                Close = Round(close[i]),
                Volume = volume[i]
            });
        }

        return new ResponseDTO
        {
            Symbol = result.Meta.Symbol,
            Data = data
        };
    }

    /**
    * Rounds a decimal to two decimal places
    * Returns null if given value is null
    */
    public static decimal? Round(decimal? value)
  {
    return value.HasValue == true ? Math.Round(value.Value, 2) : null;
  }
}