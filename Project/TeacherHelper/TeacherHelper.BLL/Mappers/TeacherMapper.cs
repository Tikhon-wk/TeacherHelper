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
    public class TeacherMapper : ITeacherMapper
    {
        public Teacher FromDTO(TeacherDTO data)
        {
            return new Teacher
            {
                Id = data.Id,
                Name = data.Name,
                Surname = data.Surname
            };
        }

        public List<Teacher> FromDTO(List<TeacherDTO> list)
        {
            List<Teacher> teachers = new List<Teacher>();
            foreach (var item in list)
                teachers.Add(this.FromDTO(item));
            return teachers != null ? teachers : throw new NullReferenceException();
        }

        public TeacherDTO ToDTO(Teacher data)
        {
            return new TeacherDTO
            {
                Id = data.Id,
                Name = data.Name,
                Surname = data.Surname
            };
        }

        public List<TeacherDTO> ToDTO(List<Teacher> list)
        {
            List<TeacherDTO> teachers = new List<TeacherDTO>();
            foreach (var item in list)
                teachers.Add(this.ToDTO(item));
            return teachers != null ? teachers : throw new NullReferenceException();
        }
    }
}
