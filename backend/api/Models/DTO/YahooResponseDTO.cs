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
    public List<long> Timestamp { get; set; } = [];
    public Indicator Indicators { get; set; } = new();
}

public class Meta
{
    public string Symbol { get; set; } = "";
}

public class Indicator
{
    public List<Quote> Quote { get; set; } = new();
}

public class Quote
{
    public List<decimal?> High { get; set; } = [];
    public List<decimal?> Low { get; set; } = [];
    public List<decimal?> Open { get; set; } = [];
    public List<decimal?> Close { get; set; } = [];
    public List<long?> Volume { get; set; } = [];
}