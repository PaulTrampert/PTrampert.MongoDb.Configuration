using System.Configuration;

namespace PTrampert.MongoDb.Configuration
{
    public class HostCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new Host();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            var host = (Host) element;
            return $"{host.Name}:{host.Port}";
        }

        public void Add(Host host)
        {
            BaseAdd(host);
        }

        public void Clear()
        {
            BaseClear();
        }

        public void Remove(Host host)
        {
            BaseRemove(GetElementKey(host));
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }
    }
}