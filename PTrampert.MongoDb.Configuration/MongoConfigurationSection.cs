﻿using System.Configuration;

namespace PTrampert.MongoDb.Configuration
{
    public class MongoConfigurationSection : ConfigurationSection, IMongoConfiguration
    {
        private const string ConnectionStringPropertyName = "connectionString";
        private const string DatabaseNamePropertyName = "databaseName";

        [ConfigurationProperty(ConnectionStringPropertyName, DefaultValue = "mongodb://localhost/?w=majority", IsRequired = false)]
        public string ConnectionString
        {
            get { return (string) this[ConnectionStringPropertyName]; }
            set { this[ConnectionStringPropertyName] = value; }
        }

        [ConfigurationProperty(DatabaseNamePropertyName, IsRequired = true)]
        public string DatabaseName
        {
            get { return (string) this[DatabaseNamePropertyName]; }
            set { this[DatabaseNamePropertyName] = value; }
        }
    }
}