using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PTrampert.MongoDb.Configuration.Test
{
    [TestFixture]
    class MongoConfigurationSectionTests
    {
        private MongoConfigurationSection Config { get; set; }

        [SetUp]
        public void SetUp()
        {
            Config = new MongoConfigurationSection();
        }

        [Test]
        public void CanReadAndWriteConnectionString()
        {
            Config.ConnectionString = "this is a test";
            Assert.That(Config.ConnectionString, Is.EqualTo("this is a test"));
        }

        [Test]
        public void CanReadAndWriteDatabaseName()
        {
            Config.DatabaseName = "this is a test";
            Assert.That(Config.DatabaseName, Is.EqualTo("this is a test"));
        }
    }
}
