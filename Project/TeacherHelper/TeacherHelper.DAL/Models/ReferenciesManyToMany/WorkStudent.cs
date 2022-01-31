using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherHelper.DAL.Models.ReferenciesManyToMany
{
    public class WorkStudent
    {
        public string StudentId { get; set; }
        public virtual Student Student { get; set; }

        public string WorkId { get; set; }
        public virtual Work Work { get; set; }
    }
}
