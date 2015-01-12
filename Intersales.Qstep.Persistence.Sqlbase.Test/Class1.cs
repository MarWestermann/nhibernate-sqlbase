using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intersales.Qstep.Persistence.Sqlbase.Repositories;
using Intersales.Qstep.Persistence.Sqlbase.Domain;
using log4net;
using log4net.Repository.Hierarchy;
using log4net.Appender;
using log4net.Layout;
using NHibernate;

namespace Intersales.Qstep.Persistence.Sqlbase.Test
{
    [TestFixture]
    public class DBTest
    {
        private ISession _session = null;

        [TestFixtureSetUp]
        public void Setup()
        {
            _session = NHibernateHelper.OpenSession();
            
            //var hierarchy = (Hierarchy)LogManager.GetRepository();
            //var logger = (Logger)hierarchy.GetLogger("NHibernate.SQL");
            //logger.AddAppender(new ConsoleAppender { Layout = new SimpleLayout() });
            //hierarchy.Configured = true;
        }

        [Test]
        public void TestDbSelect()
        {
            var repo = new CountryRepository(_session);
            var countries = repo.GetByName("Deutschland");

            Assert.NotNull(countries);

            Assert.AreEqual(1, countries.Count);
            Assert.AreEqual("Deutschland", countries.ElementAt(0).Name);
        }

        [Test]
        public void TestDbInsert()
        {

            for (int i = 0; i <= 10; i++)
            {
                var repo = new CountryRepository(_session);

                

                using (var transaction = _session.BeginTransaction())
                {
                    DeleteByName(repo, "Köln");
                    var country = new Country();
                    country.Name = "Köln";
                    repo.Save(country);
                    transaction.Commit();
                }

                var countries = repo.GetByName("Köln");
                Assert.AreEqual(1, countries.Count);
            }
        }

        [Test]
        public void TestDbDelete()
        {
            var repo = new CountryRepository(_session);

            using (var transaction = _session.BeginTransaction()) { 
                var country = new Country();
                country.Name = "Köln";
                repo.Save(country);
                DeleteByName(repo, "Köln");
                transaction.Commit();
            }

            

            var countries = repo.GetByName("Köln");
            Assert.AreEqual(0, countries.Count);
        }

        private static void DeleteByName(CountryRepository repo, String name)
        {
            var countries = repo.GetByName(name);
            foreach (var c in countries)
            {
                repo.Remove(c);
            }
        }

        [Test]
        public void TestDbUpdate()
        {
            using (var transaction = _session.BeginTransaction())
            {
                var repo = new CountryRepository(_session);
                DeleteByName(repo, "Köln");
                

                var country = new Country();
                country.Name = "Köln";
                repo.Save(country);
                

                country.Name = "BlaLand";
                repo.Save(country);
                

                var countries = repo.GetByName("BlaLand");
                Assert.AreEqual(1, countries.Count);
                DeleteByName(repo, "BlaLand");
                transaction.Commit();
            }
        }

        [Test]
        public void TestDbSelectAll()
        {
            var repo = new CountryRepository(NHibernateHelper.OpenSession());
            var countries = repo.GetAll();
            Assert.Greater(countries.Count, 60);
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            if (_session != null && _session.IsOpen)
            {
                _session.Close();
            }
        }
    }
}
