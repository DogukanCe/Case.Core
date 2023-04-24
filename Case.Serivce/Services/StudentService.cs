using Case.Core.Model;
using Case.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case.Serivce.Services
{

  
    public class StudentService
    {
        private readonly IGenericRepository<Student> repository;

        public StudentService(IGenericRepository<Student> repository)
        {
            this.repository = repository;
        }

        public IList<Student> GetAll()
        {
            return repository.GetAll();
        }

        public Student GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Insert(Student entity)
        {
            repository.Insert(entity);
        }

        public void Update(Student entity)
        {
            repository.Update(entity);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }
    }
}
