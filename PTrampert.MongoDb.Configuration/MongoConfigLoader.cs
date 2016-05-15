using System.Configuration;

namespace PTrampert.MongoDb.Configuration
{
    public static class MongoConfigLoader
    {
        public static IMongoConfiguration LoadFromConfigFile(string sectionName = "mongodb")
        {
            return ConfigurationManager.GetSection(sectionName) as IMongoConfiguration;
        }
    }
}
