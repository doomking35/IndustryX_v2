namespace IndustryX.LogisticsService.Core.Entities.Records;

public sealed record GeneralExceptionHandleRecord
{
    public required string ExceptionMessage { get; init; }
    public required int ExceptionStatusCode { get; init; }
    public required string ExceptionFrom { get; init; }
};