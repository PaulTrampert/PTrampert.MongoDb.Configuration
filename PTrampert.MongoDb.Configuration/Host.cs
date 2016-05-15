using System.Configuration;

namespace PTrampert.MongoDb.Configuration
{
    public class Host : ConfigurationElement
    {
        private const string NamePropertyName = "name";
        private const string PortPropertyName = "port";

        [ConfigurationProperty(NamePropertyName, IsRequired = true)]
        public string Name
        {
            get { return (string) this[NamePropertyName]; }
            set { this[NamePropertyName] = value; }
        }

        [ConfigurationProperty(PortPropertyName, DefaultValue = 2701, IsRequired = false)]
        public int Port
        {
            get { return (int) this[PortPropertyName]; }
            set { this[PortPropertyName] = value; }
        }
    }
}