namespace PTrampert.MongoDb.Configuration
{
    public interface IMongoConfiguration
    {
        string ConnectionString { get; }
        string DatabaseName { get; }
    }
}