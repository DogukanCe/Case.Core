using Case.Core.Model;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case.Core.Helper
{
    public static class NHibernateHelper
    {
        private static ISessionFactory sessionFactory;

        public static ISession OpenSession()
        {
            if (sessionFactory == null)
            {
                var connectionString = Configuration.GetConnectionString("DefaultConnection");
                var configuration = new Configuration();
                configuration.DataBaseIntegration(db =>
                {
                    db.ConnectionString = connectionString;
                    db.Driver<SQLite20Driver>();
                    db.Dialect<SQLiteDialect>();
                    db.SchemaAction = SchemaAutoAction.Create;
                });
                configuration.AddAssembly(typeof(Student).Assembly);
                configuration.AddAssembly(typeof(StudentGrades).Assembly);
                sessionFactory = configuration.BuildSessionFactory();
            }

            return sessionFactory.OpenSession();
        }
    }
}
