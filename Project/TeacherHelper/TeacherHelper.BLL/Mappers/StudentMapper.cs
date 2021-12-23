using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherHelper.BLL.Interfaces.Mapper;
using TeacherHelper.BLL.ModelsDTO;
using TeacherHelper.DAL.Models;

namespace TeacherHelper.BLL.Mappers
{
    public class StudentMapper : IStudentMapper
    {
        public Student FromDTO(StudentDTO data)
        {
            return new Student
            {
                Id = data.Id,
                Name = data.Name,
                Surname = data.Surname,
                GroupId = data.GroupId
            };
        }

        public StudentDTO ToDTO(Student data)
        {
            return new StudentDTO
            {
                Id = data.Id,
                Name = data.Name,
                Surname = data.Surname,
                GroupId = data.GroupId
            };
        }
        public List<Student> FromDTO(List<StudentDTO> list)
        {
            List<Student> students = new List<Student>();
            foreach (var item in list)
            {
                students.Add(this.FromDTO(item));
            }
            return students;
        }

        public List<StudentDTO> ToDTO(List<Student> list)
        {
            List<StudentDTO> students = new List<StudentDTO>();
            foreach (var item in list)
            {
                students.Add(this.ToDTO(item));
            }
            return students;
        }
    }
}
