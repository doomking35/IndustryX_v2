using IndustryX.LogisticsService.Core.Entities.Records;

namespace IndustryX.LogisticsService.Core.DTOs;

public record DeliveryDto
{
    public required int DeliveryId { get; init; }
    public required string DeliveryLabel { get; init; }
    public required DateTime DeliveryCreatedDate { get; init; }
    public required DateTime DeliveryLastUpdateDate { get; init; }
    public required ShipmentAddress ShipmentAddress { get; init; }
}