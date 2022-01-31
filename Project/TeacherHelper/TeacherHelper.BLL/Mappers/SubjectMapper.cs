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
    public class SubjectMapper : ISubjectMapper
    {
        public Subject FromDTO(SubjectDTO data)
        {
            return new Subject
            {
                Id = data.Id,
                Name = data.Name,
                Hours = data.Hours
            };
        }

        public List<Subject> FromDTO(List<SubjectDTO> list)
        {
            List<Subject> subjects = new List<Subject>();
            foreach (var item in list)
                subjects.Add(this.FromDTO(item));
            return subjects != null ? subjects : throw new NullReferenceException();
        }

        public SubjectDTO ToDTO(Subject data)
        {
            return new SubjectDTO
            {
                Id = data.Id,
                Name = data.Name,
                Hours = data.Hours
            };
        }

        public List<SubjectDTO> ToDTO(List<Subject> list)
        {
            List<SubjectDTO> subjects = new List<SubjectDTO>();
            foreach (var item in list)
                subjects.Add(this.ToDTO(item));
            return subjects != null ? subjects : throw new NullReferenceException();
        }
    }
}
