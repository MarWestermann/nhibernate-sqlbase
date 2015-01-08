using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intersales.Qstep.Persistence.Sqlbase.Repositories;

namespace Intersales.Qstep.Persistence.Sqlbase.Test
{
    [TestFixture]
    public class DBTest
    {
        [Test]
        public void TestDbSelect()
        {
            var repo = new CountryRepository();
            var countries = repo.GetByName("Deutschland");

            Assert.NotNull(countries);

            Assert.AreEqual(1, countries.Count);
            Assert.AreEqual("Deutschland", countries.ElementAt(0).Name);
        }
        [Test]
        public void TestReflect()
        {
            Reflector.Do();
        }
    }
}
