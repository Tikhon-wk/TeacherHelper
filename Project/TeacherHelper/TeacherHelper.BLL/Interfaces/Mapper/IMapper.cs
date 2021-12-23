using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherHelper.BLL.Interfaces.Mapper
{
    public interface IMapper<T,TDTO>
    {
        T FromDTO(TDTO data);
        TDTO ToDTO(T data);
        List<T> FromDTO(List<TDTO> list);
        List<TDTO> ToDTO(List<T> list);
    }
}
