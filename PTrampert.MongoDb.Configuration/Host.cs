using System.Configuration;

namespace PTrampert.MongoDb.Configuration
{
    public class Host : ConfigurationElement
    {
        private const string NamePropertyName = "name";
        private const string PortPropertyName = "port";

        public Host(string name, int port)
        {
            Name = name;
            Port = port;
        }

        public Host()
        {
            Port = 27017;
        }

        [ConfigurationProperty(NamePropertyName, IsRequired = true)]
        public string Name
        {
            get { return (string) this[NamePropertyName]; }
            set { this[NamePropertyName] = value; }
        }

        [ConfigurationProperty(PortPropertyName, DefaultValue = 27017, IsRequired = false)]
        public int Port
        {
            get { return (int) this[PortPropertyName]; }
            set { this[PortPropertyName] = value; }
        }

        public override string ToString()
        {
            return $"{Name}:{Port}";
        }
    }
}