using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherHelper.BLL.Interfaces;
using TeacherHelper.BLL.Interfaces.Mapper;
using TeacherHelper.BLL.ModelsDTO;
using TeacherHelper.DAL.Interfaces;

namespace TeacherHelper.BLL.Services
{
    public class WorkService : IWorkService
    {
        private IWorkRepository repository;
        private IWorkMapper mapper;
        public WorkService(IWorkRepository repository, IWorkMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public void Create(WorkDTO data)
        {
            if (data == null)
                throw new NullReferenceException();
            repository.Create(mapper.FromDTO(data));
        }

        public void Delete(string id)
        {
            repository.Delete(id);
        }

        public WorkDTO Read(string id)
        {
            return mapper.ToDTO(repository.Read(id));
        }

        public List<WorkDTO> ReadAll()
        {
            return mapper.ToDTO(repository.ReadAll());
        }

        public void Update(WorkDTO data)
        {
            if (data == null)
                throw new NullReferenceException();
        }
    }
}
