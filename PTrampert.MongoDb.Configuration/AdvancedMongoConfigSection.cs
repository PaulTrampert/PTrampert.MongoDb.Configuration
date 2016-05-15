using System.Configuration;

namespace PTrampert.MongoDb.Configuration
{
    public class AdvancedMongoConfigSection : ConfigurationSection, IMongoConfiguration
    {
        private const string DatabaseNamePropertyName = "databaseName";
        private const string UsernamePropertyName = "username";
        private const string PasswordPropertyName = "password";
        private const string HostsPropertyName = "hosts";
        private const string PropertiesPropertyName = "properties";

        [ConfigurationProperty(UsernamePropertyName, IsRequired = false)]
        public string Username
        {
            get { return (string) this[UsernamePropertyName]; }
            set { this[UsernamePropertyName] = value; }
        }

        [ConfigurationProperty(PasswordPropertyName, IsRequired = false)]
        public string Password
        {
            get { return (string) this[PasswordPropertyName]; }
            set { this[PasswordPropertyName] = value; }
        }

        [ConfigurationProperty(HostsPropertyName, IsRequired = true)]
        public HostCollection Hosts
        {
            get { return (HostCollection) this[HostsPropertyName]; }
            set { this[HostsPropertyName] = value; }
        }

        [ConfigurationProperty(PropertiesPropertyName, IsRequired = false)]
        public NameValueConfigurationCollection Properties
        {
            get { return (NameValueConfigurationCollection) this[PropertiesPropertyName]; }
            set { this[PropertiesPropertyName] = value; }
        }

        public string ConnectionString { get; }

        [ConfigurationProperty(DatabaseNamePropertyName, IsRequired = true)]
        public string DatabaseName
        {
            get { return (string) this[DatabaseNamePropertyName]; }
            set { this[DatabaseNamePropertyName] = value; }
        }
    }
}