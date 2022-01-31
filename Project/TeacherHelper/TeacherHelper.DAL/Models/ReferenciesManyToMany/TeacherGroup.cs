using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherHelper.DAL.Models.ReferenciesManyToMany
{
    public class TeacherGroup
    {
        public string TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        public string GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}
