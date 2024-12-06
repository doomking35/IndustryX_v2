using IndustryX.LogisticsService.Core.Entities.Abstractions;

namespace IndustryX.LogisticsService.Core.Entities;

public class Delivery : LogisticBase
{
    public required int DeliveryId { get; init; }
    public required string DeliveryLabel { get; init; }
    public required DateTime DeliveryCreatedDate { get; init; }
    public required DateTime DeliveryLastUpdateDate { get; init; }
}