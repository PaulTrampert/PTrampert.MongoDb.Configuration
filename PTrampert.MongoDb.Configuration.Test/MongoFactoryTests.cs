using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using NUnit.Framework;

namespace PTrampert.MongoDb.Configuration.Test
{
    [TestFixture]
    public class MongoFactoryTests
    {
        [Test]
        public void CanConstructFromConfigObject()
        {
            var config = new MongoConfigurationSection();
            Assert.DoesNotThrow(() => new MongoFactory(config));
        }

        [Test]
        public void CreatesMongoClientFromConfig()
        {
            var result = new MongoFactory().Client;
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void MongoClientIsConfiguredProperly()
        {
            var result = new MongoFactory().Client;
            Assert.That(result.Settings.WriteConcern, Is.EqualTo(WriteConcern.WMajority));
        }

        [Test]
        public void MongoDatabaseGetsDatabaseFromConfig()
        {
            var result = new MongoFactory().Database;
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void MongoDatabaseIsCorrect()
        {
            var result = new MongoFactory().Database;
            Assert.That(result.DatabaseNamespace.DatabaseName, Is.EqualTo("testdb"));
        }
    }
}
