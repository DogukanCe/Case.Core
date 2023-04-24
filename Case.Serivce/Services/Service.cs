using Case.Core.Services;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case.Serivce.Services
{/*Test İşlemi*/
    public class Service<T> : IServices<T> where T : class
    {
        private readonly ISession _session;
        public Service(ISession session)
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
