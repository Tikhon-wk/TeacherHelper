using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherHelper.DAL.Models
{
    public class Teacher
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public virtual List<Subject> Subjects { get; set; }
    }
}
