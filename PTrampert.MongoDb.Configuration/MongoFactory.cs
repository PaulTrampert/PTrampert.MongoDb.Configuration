using MongoDB.Driver;

namespace PTrampert.MongoDb.Configuration
{
    public class MongoFactory : IMongoFactory
    {
        private readonly IMongoConfiguration _mongoConfiguration;

        private IMongoClient _client;

        private IMongoDatabase _database;

        public MongoFactory(IMongoConfiguration mongoConfiguration)
        {
            _mongoConfiguration = mongoConfiguration;
        }

        public MongoFactory()
        {
            _mongoConfiguration = MongoConfigLoader.LoadFromConfigFile();
        }

        public IMongoClient Client => _client ?? (_client = new MongoClient(_mongoConfiguration.ConnectionString));

        public IMongoDatabase Database => _database ?? (_database = Client.GetDatabase(_mongoConfiguration.DatabaseName));
    }
}