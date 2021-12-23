using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherHelper.DAL.Models.ReferenciesManyToMany
{
    public class TeacherSubject
    {
        public string TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        public string SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
