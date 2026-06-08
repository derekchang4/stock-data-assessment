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
}

public class Meta
{
    public string Symbol { get; set; } = "";
}