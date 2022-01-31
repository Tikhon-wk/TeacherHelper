using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherHelper.DAL.Enums;

namespace TeacherHelper.DAL.Models
{
    public class Work
    {
        public string Id { get; set; }
        public WorkType Type { get; set; }
        public int Result { get; set; }

        public virtual List<Student> Students { get; set; }
    }
}
