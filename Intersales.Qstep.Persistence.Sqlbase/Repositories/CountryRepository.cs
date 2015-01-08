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
        public void Add()
        {

        }

        void Update()
        {

        }

        void Remove()
        {

        }

        public Country GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    transaction.Commit();
                    return null;
                }
        }

        public ICollection<Country> GetByName(String name)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session
                    .CreateCriteria(typeof(Country))
                    .Add(Restrictions.Eq("Name", name))
                    .List<Country>();
            }
                
                
                 
        }

    }
}
