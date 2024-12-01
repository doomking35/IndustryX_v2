namespace IndustryX.LogisticsService.Infrastructure.DAL;

public class MongoDBSettings<T> where T : System.Enum
{
    public string ConnectionURI { get; set; }
    public string DatabaseName { get; set; }
    public string CollectionName { get; set; }
}