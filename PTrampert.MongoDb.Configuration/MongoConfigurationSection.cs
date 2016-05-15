using System.Configuration;

namespace PTrampert.MongoDb.Configuration
{
    public class MongoConfigurationSection : ConfigurationSection, IMongoConfiguration
    {
        private const string ConnectionStringPropertyName = "connectionString";
        private const string DatabaseNamePropertyName = "databaseName";

        [ConfigurationProperty(ConnectionStringPropertyName, IsRequired = true)]
        public string ConnectionString
        {
            get { return (string) this[ConnectionStringPropertyName]; }
            set { this[ConnectionStringPropertyName] = value; }
        }

        [ConfigurationProperty(DatabaseNamePropertyName, IsRequired = false)]
        public string DatabaseName
        {
            get { return (string) this[DatabaseNamePropertyName]; }
            set { this[DatabaseNamePropertyName] = value; }
        }
    }
}
