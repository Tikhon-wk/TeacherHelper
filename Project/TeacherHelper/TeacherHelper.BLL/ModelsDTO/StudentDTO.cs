using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherHelper.BLL.ModelsDTO
{
    public class StudentDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public double AvarageMark { get; set; }
        public string GroupId { get; set; }
    }
}
