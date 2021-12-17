using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherHelper.DAL.Models
{
    public class Group
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual List<Student> Students { get; set; }
    }
}
