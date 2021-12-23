using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherHelper.BLL.ModelsDTO;
using TeacherHelper.DAL.Models;

namespace TeacherHelper.BLL.Interfaces.Mapper
{
    public interface ITeacherMapper : IMapper<Teacher, TeacherDTO>
    {
    }
}
