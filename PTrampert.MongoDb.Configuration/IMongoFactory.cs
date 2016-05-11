using MongoDB.Driver;

namespace PTrampert.MongoDb.Configuration
{
    public interface IMongoFactory
    {
        IMongoClient GetClient();
    }
}