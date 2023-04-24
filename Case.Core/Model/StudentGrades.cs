using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case.Core.Model
{
    public class StudentGrades
    {
        public virtual int Id { get; set; }
        public virtual int Note { get; set; }
        public virtual Student Student { get; set; }
    }
}
