namespace api.Models;
public class Quote
{
    public List<decimal?> High { get; set; } = [];
    public List<decimal?> Low { get; set; } = [];
    public List<decimal?> Open { get; set; } = [];
    public List<decimal?> Close { get; set; } = [];
    public List<long?> Volume { get; set; } = [];
}