using Case.Core.Repositories;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ISession _session;
        public GenericRepository(ISession session)
        {
            _session = session;
        }
        public void Delete(int id)
        {
            var entity = _session.Load<T>(id);
            _session.Delete(entity);
            _session.Flush();
        }

        public IList<T> GetAll()
        {
            return _session.Query<T>().ToList();
        }

        public T GetById(int id)
        {
            return _session.Get<T>(id);
        }

        public void Insert(T entity)
        {
            _session.Save(entity);
            _session.Flush();
        }

        public void Update(T entity)
        {
            _session.Update(entity);
            _session.Flush();
        }
    }
}
