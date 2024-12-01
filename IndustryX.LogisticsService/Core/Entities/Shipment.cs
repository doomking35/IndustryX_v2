using IndustryX.LogisticsService.Core.Entities.Records;

namespace IndustryX.LogisticsService.Core.Entities;

public class Shipment
{
    public required int ShipmentId { get; set; }
    public required string ShipmentDescription { get; set; }
    public required ShipmentAddress ShipmentAddress { get; set; }
    public required CustomerInfo CustomerInfo { get; set; } = new CustomerInfo();
}

