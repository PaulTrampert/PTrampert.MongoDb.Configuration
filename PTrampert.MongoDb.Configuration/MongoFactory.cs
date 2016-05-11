using MongoDB.Driver;

namespace PTrampert.MongoDb.Configuration
{
    public class MongoFactory : IMongoFactory
    {
        private readonly IMongoConfiguration _mongoConfiguration;

        public MongoFactory(IMongoConfiguration mongoConfiguration)
        {
            _mongoConfiguration = mongoConfiguration;
        }

        public MongoFactory()
        {
            _mongoConfiguration = MongoConfigLoader.LoadFromConfigFile();
        }

        public IMongoClient GetClient()
        {
            return new MongoClient(_mongoConfiguration.ConnectionString);
        }
    }
}