using System.ComponentModel;

namespace IndustryX.LogisticsService.Infrastructure.Data;

public enum MongoDbServiceTypeEnum
{
    [Description("ShipmentService")]
    Shipment,
    [Description("DeliveryService")]
    Delivery
}