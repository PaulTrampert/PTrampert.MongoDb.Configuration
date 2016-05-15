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

        [Test]
        public void ProperlyLoadsAdvancedMongoConfiguration()
        {
            var config = MongoConfigLoader.LoadFromConfigFile("mongodbAdv");
            Assert.That(config.ConnectionString, Is.EqualTo("mongodb://tester:asdfasdf@remote1:27017,remote2:222/somedb?w=majority&j=1"));
        }
    }
}
