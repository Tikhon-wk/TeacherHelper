using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherHelper.BLL.Interfaces;
using TeacherHelper.BLL.Interfaces.Mapper;
using TeacherHelper.BLL.ModelsDTO;
using TeacherHelper.DAL.Interfaces;
using TeacherHelper.DAL.Repositories;

namespace TeacherHelper.BLL.Services
{
    public class TeacherService : ITeacherService
    {
        private ITeacherRepository repository;
        private ITeacherMapper mapper;
        public TeacherService(ITeacherRepository repository,ITeacherMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public void Create(TeacherDTO data)
        {
            repository.Create(mapper.FromDTO(data));
        }

        public void Delete(string id)
        {
            repository.Delete(id);
        }


        public TeacherDTO Read(string id)
        {
            return mapper.ToDTO(repository.Read(id));
        }

        public List<TeacherDTO> ReadAll()
        {
            return mapper.ToDTO(repository.ReadAll());
        }

        public void Update(TeacherDTO data)
        {
            repository.Update(mapper.FromDTO(data));
        }
    }
}
