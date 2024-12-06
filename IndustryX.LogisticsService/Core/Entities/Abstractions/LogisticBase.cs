using IndustryX.LogisticsService.Core.Entities.Records;

namespace IndustryX.LogisticsService.Core.Entities.Abstractions;

public abstract class LogisticBase
{
    public required int ShipmentId { get; set; }
    public required ShipmentAddress ShipmentAddress { get; init; }

    public virtual DateTime GetDate()
    {
        return DateTime.Now.Date;
    }
    
}