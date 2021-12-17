using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherHelper.DAL.Models
{
    public class Student
    {
        public string Id { get; set; }
        public string Surname { get; set; }

        public virtual Group Group { get; set; }
    }
}
