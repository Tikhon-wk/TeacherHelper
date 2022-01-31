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
        public string Name { get; set; }
        public string Surname { get; set; }
        public double AvarageMark { get; set; }

        public string GroupId { get; set; }
        public virtual Group Group { get; set; }

        public virtual List<Work> Works { get; set; } = new List<Work>();
    }
}
