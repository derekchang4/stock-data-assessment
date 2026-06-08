namespace api.Models.DTO;
public class ResponseDTO
{
  public required string Symbol {get; set;}
  public List<DayData> Data {get; set;} = [];

}