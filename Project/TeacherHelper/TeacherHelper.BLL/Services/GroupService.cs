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
    public class GroupService : IGroupService
    {
        private GroupRepository repository;
        public GroupService(GroupRepository repository)
        {
            this.repository = repository;
        }
        public void Create(GroupDTO data)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public void Delete(GroupDTO data)
        {
            throw new NotImplementedException();
        }

        public GroupDTO Read(string id)
        {
            throw new NotImplementedException();
        }

        public List<GroupDTO> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(GroupDTO data)
        {
            throw new NotImplementedException();
        }
    }
}
