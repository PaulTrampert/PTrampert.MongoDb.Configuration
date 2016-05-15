using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using NUnit.Framework;

namespace PTrampert.MongoDb.Configuration.Test
{
    [TestFixture]
    public class AdvancedMongoConfigSectionTests
    {
        private AdvancedMongoConfigSection Config { get; set; }

        [SetUp]
        public void SetUp()
        {
            Config = new AdvancedMongoConfigSection();
        }

        [Test]
        public void CanReadWriteUsername()
        {
            Config.Username = "tester";
            Assert.That(Config.Username, Is.EqualTo("tester"));
        }

        [Test]
        public void CanReadWritePassword()
        {
            Config.Password = "asdfasdf";
            Assert.That(Config.Password, Is.EqualTo("asdfasdf"));
        }

        [Test]
        public void CanReadWriteHosts()
        {
            var hosts = new HostCollection();
            hosts.Add(new Host {Name = "test", Port = 333});
            Config.Hosts = hosts;
            var host = Config.Hosts.OfType<Host>().Single();
            Assert.That(host.Name, Is.EqualTo("test"));
            Assert.That(host.Port, Is.EqualTo(333));
        }

        [Test]
        public void CanReadWriteDatabaseName()
        {
            Config.DatabaseName = "testdb";
            Assert.That(Config.DatabaseName, Is.EqualTo("testdb"));
        }

        [Test]
        public void CanReadWriteProperties()
        {
            Config.Properties = new NameValueConfigurationCollection();
            Config.Properties.Add(new NameValueConfigurationElement("thing", "stuff"));
            var element = Config.Properties.Cast<NameValueConfigurationElement>().First();
            Assert.That(element.Name, Is.EqualTo("thing"));
            Assert.That(element.Value, Is.EqualTo("stuff"));
        }
    }
}
