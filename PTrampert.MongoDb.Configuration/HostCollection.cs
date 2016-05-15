using System;
using System.Configuration;

namespace PTrampert.MongoDb.Configuration
{
    [ConfigurationCollection(typeof(Host))]
    public class HostCollection : ConfigurationElementCollection
    {
        internal const string PropertyName = "host";

        protected override string ElementName => PropertyName;

        protected override bool IsElementName(string elementName)
        {
            return elementName.Equals(PropertyName, StringComparison.InvariantCultureIgnoreCase);
        }

        public override ConfigurationElementCollectionType CollectionType => ConfigurationElementCollectionType.BasicMapAlternate;

        public override bool IsReadOnly()
        {
            return false;
        }

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

        public Host this[int idx] => (Host) BaseGet(idx);
    }
}