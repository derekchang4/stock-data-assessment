namespace api.Models.DTO;
/**
* Represents the response served by the API
*/
public class ResponseDTO
{
  public required string Symbol {get; set;}
  public List<DayData> Data {get; set;} = [];

}