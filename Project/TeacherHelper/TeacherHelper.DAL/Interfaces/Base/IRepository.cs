using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherHelper.DAL.Interfaces.Base
{
    public interface IRepository<T>
    {
        void Create(T data);
        T Read(string id);
        void Update(T data);
        void Delete(string id);
        List<T> ReadAll();
    }
}
