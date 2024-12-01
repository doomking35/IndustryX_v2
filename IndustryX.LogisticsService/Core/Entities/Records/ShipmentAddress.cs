using System.Reflection.Metadata;

namespace IndustryX.LogisticsService.Core.Entities.Records;

public record ShipmentAddress(int ShipmentId)
{
    public int ShipmentId { get; private set; } = ShipmentId;
    public int CityId { get; init; }
    public string City { get; init; } = string.Empty;
    public  string Province { get; init; } = string.Empty;
    public int ZipCode { get; init; }
    public string AdditionalAddress1 { get; init; } = string.Empty;
    public string AdditionalAddress2 { get; init; } = string.Empty;
}