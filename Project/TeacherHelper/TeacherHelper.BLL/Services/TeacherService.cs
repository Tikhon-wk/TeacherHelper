using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherHelper.BLL.Interfaces;
using TeacherHelper.BLL.ModelsDTO;
using TeacherHelper.DAL.Repositories;

namespace TeacherHelper.BLL.Services
{
    public class TeacherService : ITeacherService
    {
        private TeacherRepository repository;
        public TeacherService(TeacherRepository repository)
        {
            this.repository = repository;
        }
        public void Create(TeacherDTO data)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public void Delete(TeacherDTO data)
        {
            throw new NotImplementedException();
        }

        public TeacherDTO Read(string id)
        {
            throw new NotImplementedException();
        }

        public List<TeacherDTO> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(TeacherDTO data)
        {
            throw new NotImplementedException();
        }
    }
}
