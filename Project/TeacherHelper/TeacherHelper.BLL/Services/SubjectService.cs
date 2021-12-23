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
    public class SubjectService : ISubjectService
    {
        private ISubjectRepository repository;
        private ISubjectMapper mapper;
        public SubjectService(ISubjectRepository repository,ISubjectMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public void Create(SubjectDTO data)
        {
            repository.Create(mapper.FromDTO(data));
        }

        public void Delete(string id)
        {
            repository.Delete(id);
        }
        public SubjectDTO Read(string id)
        {
            return mapper.ToDTO(repository.Read(id));
        }

        public List<SubjectDTO> ReadAll()
        {
            return mapper.ToDTO(repository.ReadAll());
        }
        /// <summary>
        /// Guesse will be some problems with updating references
        /// </summary>
        /// <param name="data"></param>
        public void Update(SubjectDTO data)
        {
            repository.Update(mapper.FromDTO(data));
        }
    }
}
