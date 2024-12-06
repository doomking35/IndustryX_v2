using IndustryX.LogisticsService.Core.Entities.Abstractions;
using IndustryX.LogisticsService.Core.Entities.Records;

namespace IndustryX.LogisticsService.Core.Entities;

public class Shipment : LogisticBase
{
    public required string ShipmentDescription { get; set; }
    public required CustomerInfo CustomerInfo { get; set; } = new CustomerInfo();
    
}

