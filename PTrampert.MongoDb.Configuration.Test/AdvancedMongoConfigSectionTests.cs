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
            Config.ConnectionProperties = new NameValueConfigurationCollection();
            Config.ConnectionProperties.Add(new NameValueConfigurationElement("thing", "stuff"));
            var element = Config.ConnectionProperties.Cast<NameValueConfigurationElement>().First();
            Assert.That(element.Name, Is.EqualTo("thing"));
            Assert.That(element.Value, Is.EqualTo("stuff"));
        }

        [Test]
        public void MinimalConnectionStringIsCorrect()
        {
            Config.Hosts = new HostCollection();
            Config.Hosts.Add(new Host {Name = "localhost"});
            Config.DatabaseName = "SomeDb";
            Assert.That(Config.ConnectionString, Is.EqualTo("mongodb://localhost:27017/SomeDb"));
        }

        [Test]
        public void FullConnectionStringIsCorrect()
        {
            Config.Hosts = new HostCollection();
            Config.Hosts.Add(new Host { Name = "remote1.test.com", Port = 123 });
            Config.Hosts.Add(new Host { Name = "remote2.test.com", Port = 456 });
            Config.Hosts.Add(new Host { Name = "remote3.test.com", Port = 789 });
            Config.DatabaseName = "SomeDb";
            Config.Username = "tester";
            Config.Password = "asdfasdf";
            Config.ConnectionProperties = new NameValueConfigurationCollection();
            Config.ConnectionProperties.Add(new NameValueConfigurationElement("w", "majority"));
            Config.ConnectionProperties.Add(new NameValueConfigurationElement("j", "1"));
            Config.ConnectionProperties.Add(new NameValueConfigurationElement("has&encoded", "chara(ter"));
            Assert.That(Config.ConnectionString, Is.EqualTo("mongodb://tester:asdfasdf@remote1.test.com:123,remote2.test.com:456,remote3.test.com:789/SomeDb?w=majority&j=1&has%26encoded=chara(ter"));
        }
    }
}
