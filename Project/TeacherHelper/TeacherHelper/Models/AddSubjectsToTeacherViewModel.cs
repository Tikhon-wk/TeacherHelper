using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherHelper.BLL.ModelsDTO;

namespace TeacherHelper.Models
{
    public class AddSubjectsToTeacherViewModel
    {
        public TeacherDTO Teacher { get; set; }
        public List<SubjectDTO> Subjects { get; set; }
        public string TeacherToString()
        {
            return Teacher.Name + " " + Teacher.Surname;
        }
    }
}
