using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case.Core.Model
{
    public class Student
    {
        public virtual int Id { get; set; }
        public virtual string StudentNumber { get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
    }
}
