using Case.Core.Model;
using Case.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case.Serivce.Services
{
 
    public class StudentGradesService
    {
        private readonly IGenericRepository<StudentGrades> repository;

        public StudentGradesService(IGenericRepository<StudentGrades> repository)
        {
            this.repository = repository;
        }

        public IList<StudentGrades> GetAll()
        {
            return repository.GetAll();
        }

        public StudentGrades GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Insert(StudentGrades entity)
        {
            repository.Insert(entity);
        }

        public void Update(StudentGrades entity)
        {
            repository.Update(entity);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }
    }
}
