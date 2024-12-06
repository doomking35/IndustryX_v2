namespace IndustryX.LogisticsService.Core.DTOs;

public record DeliveryStatusDto
{
    public required string DeliveryLabel { get; init; }
    public required string DeliveryStatusInfo { get; init; }
    public required byte DeliveryStatusCode { get; init; }
    public required DateTime DeliveryLastUpdateTime { get; init; }
}