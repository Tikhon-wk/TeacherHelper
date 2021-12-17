using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherHelper.DAL.Models.ReferenciesManyToMany
{
    public class TeachersSubjects
    {
        public virtual List<Teacher> Teachers { get; set; }
        public virtual List<Subject> Subjects { get; set; }
    }
}
