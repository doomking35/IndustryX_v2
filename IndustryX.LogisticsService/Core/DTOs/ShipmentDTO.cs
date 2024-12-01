using IndustryX.LogisticsService.Core.Entities.Records;

namespace IndustryX.LogisticsService.Core.DTOs;

public record ShipmentDto
{
    public required int ShipmentId { get; init; }
    public required string ShipmentDescription { get; init; }
    public required ShipmentAddress ShipmentAddress { get; init; }
}