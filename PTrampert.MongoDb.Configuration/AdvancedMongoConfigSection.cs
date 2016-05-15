using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;

namespace PTrampert.MongoDb.Configuration
{
    public class AdvancedMongoConfigSection : ConfigurationSection, IMongoConfiguration
    {
        private const string DatabaseNamePropertyName = "databaseName";
        private const string UsernamePropertyName = "username";
        private const string PasswordPropertyName = "password";
        private const string HostsPropertyName = "hosts";
        private const string ConnectionPropertiesPropertyName = "properties";

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

        [ConfigurationProperty(ConnectionPropertiesPropertyName, IsRequired = false)]
        public NameValueConfigurationCollection ConnectionProperties
        {
            get { return (NameValueConfigurationCollection) this[ConnectionPropertiesPropertyName]; }
            set { this[ConnectionPropertiesPropertyName] = value; }
        }

        public string ConnectionString
        {
            get
            {
                var result = new StringBuilder("mongodb://");
                if (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password))
                {
                    result.Append($"{Username}:{Password}@");
                }
                result.Append(string.Join(",", Hosts.Cast<Host>().Select(h => h.ToString())));
                result.Append($"/{DatabaseName}");
                if (ConnectionProperties.Count > 0)
                {
                    var properties = ConnectionProperties.Cast<NameValueConfigurationElement>().Select(p => $"{WebUtility.UrlEncode(p.Name)}={WebUtility.UrlEncode(p.Value)}");
                    result.Append($"?{string.Join("&", $"{string.Join("&", properties)}")}");
                }
                return result.ToString();
            }
        }

        [ConfigurationProperty(DatabaseNamePropertyName, IsRequired = true)]
        public string DatabaseName
        {
            get { return (string) this[DatabaseNamePropertyName]; }
            set { this[DatabaseNamePropertyName] = value; }
        }
    }
}