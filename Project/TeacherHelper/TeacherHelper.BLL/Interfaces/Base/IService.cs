using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherHelper.BLL.Interfaces.Base
{
    public interface IService<T>
    {
        void Create(T data);
        void Delete(string id);
        T Read(string id);
        void Update(T data);
        List<T> ReadAll();
    }
}
