using MongoDB.Driver;

namespace PTrampert.MongoDb.Configuration
{
    public interface IMongoFactory
    {
        IMongoClient Client { get; }

        IMongoDatabase Database { get; }
    }
}