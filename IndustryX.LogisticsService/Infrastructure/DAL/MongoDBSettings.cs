namespace IndustryX.LogisticsService.Infrastructure.DAL;

public class MongoDbSettings<T> where T : System.Enum
{
    public string ConnectionUri { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
    public string CollectionName { get; set; } = string.Empty;
}