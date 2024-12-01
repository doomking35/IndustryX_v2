namespace IndustryX.LogisticsService.Core.Entities.Records;

public record CustomerInfo
{
    public string CustomerID { get; init; }
    public string CustomerName { get; init; }
    public string CustomerExtID { get; init; }
}