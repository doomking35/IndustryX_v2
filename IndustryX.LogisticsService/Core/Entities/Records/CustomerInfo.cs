namespace IndustryX.LogisticsService.Core.Entities.Records;

public record CustomerInfo
{
    public string CustomerId { get; init; } = string.Empty;
    public string CustomerName { get; init; } = string.Empty;
    public string CustomerExtId { get; init; } = string.Empty;
}