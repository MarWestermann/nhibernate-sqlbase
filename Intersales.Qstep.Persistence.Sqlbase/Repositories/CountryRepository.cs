using Intersales.Qstep.Persistence.Sqlbase.Domain;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intersales.Qstep.Persistence.Sqlbase.Repositories
{
    public class CountryRepository
    {

        private ISession _session;

        public CountryRepository(ISession session)
        {
            this._session = session;
        }

        public void Save(Country country)
        {
           
            if (country.Id == null)
            {
                country.Id = 500 + new Random().Next(0, 1000);
            }
            _session.SaveOrUpdate(country);
               
        }

        public void Remove(Country country)
        {
                _session.Delete(country);

        }

        public Country GetById(int id)
        {
            return _session.Get<Country>(id);
        }

        public ICollection<Country> GetByName(String name)
        {
                return _session
                    .CreateCriteria(typeof(Country))
                    .Add(Restrictions.Eq("Name", name))
                    .List<Country>();
        }

        public ICollection<Country> GetAll()
        {
            
                return _session
                    .CreateCriteria(typeof(Country))
                    .List<Country>();
            
        }

    }
}
