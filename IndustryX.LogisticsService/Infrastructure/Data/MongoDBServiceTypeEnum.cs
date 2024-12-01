using System.ComponentModel;

namespace IndustryX.LogisticsService.Infrastructure.Data;

public enum MongoDBServiceTypeEnum
{
    [Description("ShipmentService")]
    Shipment,
    [Description("DeliveryService")]
    Delivery
}