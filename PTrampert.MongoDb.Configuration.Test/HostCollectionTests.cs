using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PTrampert.MongoDb.Configuration.Test
{
    [TestFixture]
    public class HostCollectionTests
    {
        private HostCollection Hosts { get; set; }

        [SetUp]
        public void SetUp()
        {
            Hosts = new HostCollection();
        }
    }
}
