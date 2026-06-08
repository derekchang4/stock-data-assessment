namespace api.Models;
/**
* Represents one day of data in the response
*/
public class DayData
{
  public string? Date {get; set; }
  public decimal? Open {get; set; }
  public decimal? High {get; set; }
  public decimal? Low {get; set; }
  public decimal? Close {get; set; }
  public long? Volume {get; set; }
}