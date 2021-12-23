using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherHelper.BLL.Interfaces;
using TeacherHelper.BLL.Interfaces.Mapper;
using TeacherHelper.BLL.ModelsDTO;
using TeacherHelper.DAL.Interfaces;
using TeacherHelper.DAL.Models;
using TeacherHelper.DAL.Repositories;

namespace TeacherHelper.BLL.Services
{
    public class GroupService : IGroupService
    {
        private IGroupRepository repository;
        private IGroupMapper mapper;
        public GroupService(IGroupRepository repository,IGroupMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public void Create(GroupDTO data)
        {
            repository.Create(mapper.FromDTO(data));
        }

        public void Delete(string id)
        {
            repository.Delete(id);
        }

        public GroupDTO Read(string id)
        {
            return mapper.ToDTO(repository.Read(id));
        }

        public List<GroupDTO> ReadAll()
        {
            return mapper.ToDTO(repository.ReadAll());
        }

        public void Update(GroupDTO data)
        {
            repository.Update(mapper.FromDTO(data));
        }
    }
}
