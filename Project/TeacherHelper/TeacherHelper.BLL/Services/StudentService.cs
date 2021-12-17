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
    public class StudentService : IStudentService
    {
        private StudentRepository repository;
        public StudentService(StudentRepository repository)
        {
            this.repository = repository;
        }
        public void Create(StudentDTO data)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public void Delete(StudentDTO data)
        {
            throw new NotImplementedException();
        }

        public StudentDTO Read(string id)
        {
            throw new NotImplementedException();
        }

        public List<StudentDTO> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(StudentDTO data)
        {
            throw new NotImplementedException();
        }
    }
}
