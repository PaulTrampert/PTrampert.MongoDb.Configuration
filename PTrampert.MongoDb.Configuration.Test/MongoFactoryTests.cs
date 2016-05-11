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
        public void CreatesMongoClientFromConfig()
        {
            var result = new MongoFactory().GetClient();
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void MongoClientIsConfiguredProperly()
        {
            var result = new MongoFactory().GetClient();
            Assert.That(result.Settings.WriteConcern, Is.EqualTo(WriteConcern.WMajority));
        }
    }
}
