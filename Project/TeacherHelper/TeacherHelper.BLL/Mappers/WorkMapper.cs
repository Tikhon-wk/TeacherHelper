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
    public class WorkMapper : IWorkMapper
    {
        public Work FromDTO(WorkDTO data)
        {
            return new Work
            {
                Id = data.Id,
                Result = data.Result,
                Type = data.Type
            };
        }

        public List<Work> FromDTO(List<WorkDTO> list)
        {
            List<Work> result = new List<Work>();
            foreach(var item in list)
                result.Add(this.FromDTO(item));
            return result != null ? result : throw new NullReferenceException();
        }

        public WorkDTO ToDTO(Work data)
        {
            return new WorkDTO
            {
                Id = data.Id,
                Result = data.Result,
                Type = data.Type
            };
        }

        public List<WorkDTO> ToDTO(List<Work> list)
        {
            List<WorkDTO> result = new List<WorkDTO>();
            foreach(var item in list)
                result.Add(this.ToDTO(item));
            return result != null ? result : throw new NullReferenceException();
        }
    }
}
