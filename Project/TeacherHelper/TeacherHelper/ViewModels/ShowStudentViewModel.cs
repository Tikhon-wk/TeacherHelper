using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherHelper.BLL.ModelsDTO;

namespace TeacherHelper.ViewModels
{
    public class ShowStudentViewModel
    {
        public StudentDTO Student { get; set; }
        public GroupDTO Group { get; set; }
    }
}
