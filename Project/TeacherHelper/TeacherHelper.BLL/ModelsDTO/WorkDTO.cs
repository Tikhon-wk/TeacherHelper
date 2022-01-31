using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherHelper.DAL.Enums;

namespace TeacherHelper.BLL.ModelsDTO
{
    public class WorkDTO
    {
        public string Id { get; set; }
        public WorkType Type { get; set; }
        public int Result { get; set; }
    }
}
