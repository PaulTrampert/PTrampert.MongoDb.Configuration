using NUnit.Framework;

namespace PTrampert.MongoDb.Configuration.Test
{
    [TestFixture]
    public class MongoConfigLoaderTests
    {
        [Test]
        public void ProperlyLoadsMongoConfiguration()
        {
            var config = MongoConfigLoader.LoadFromConfigFile();
            Assert.That(config.ConnectionString, Is.EqualTo("mongodb://localhost/?w=majority"));
            Assert.That(config.DatabaseName, Is.EqualTo("testdb"));
        }
    }
}
