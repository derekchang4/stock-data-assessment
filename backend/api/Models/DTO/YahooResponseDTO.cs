namespace api.Models.DTO;

/**
* Represents the response given by Yahoo's financial API
*/
public class YahooResponse
{
    public Chart Chart { get; set; } = new();
}
