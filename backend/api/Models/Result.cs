namespace api.Models;
public class Result
{
    public Meta Meta { get; set; } = new();
    public List<long> Timestamp { get; set; } = [];
    public Indicator Indicators { get; set; } = new();
}
