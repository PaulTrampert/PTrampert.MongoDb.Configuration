using System.Configuration;

namespace PTrampert.MongoDb.Configuration
{
    public static class MongoConfigLoader
    {
        public static IMongoConfiguration LoadFromConfigFile()
        {
            return ConfigurationManager.GetSection("mongodb") as MongoConfigurationSection;
        }
    }
}
