using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherHelper.BLL.Interfaces;
using TeacherHelper.BLL.Interfaces.Mapper;
using TeacherHelper.BLL.Mappers;
using TeacherHelper.BLL.ModelsDTO;
using TeacherHelper.DAL.Interfaces;
using TeacherHelper.DAL.Models;
using TeacherHelper.DAL.Repositories;

namespace TeacherHelper.BLL.Services
{
    public class StudentService : IStudentService
    {
        private IStudentRepository repository;
        private IStudentMapper mapper;
        public StudentService(IStudentRepository repository,IStudentMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public void Create(StudentDTO data)
        {
            Student student = mapper.FromDTO(data);
            repository.Create(student);
        }

        public void Delete(string id)
        {
            repository.Delete(id);
        }
        public StudentDTO Read(string id)
        {
            return mapper.ToDTO(repository.Read(id));
        }

        public List<StudentDTO> ReadAll()
        {
            return mapper.ToDTO(repository.ReadAll());
        }

        public void Update(StudentDTO data)
        {
            repository.Update(mapper.FromDTO(data));
        }
    }
}
