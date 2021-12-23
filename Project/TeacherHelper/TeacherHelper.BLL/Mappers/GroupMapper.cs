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
    public class GroupMapper : IGroupMapper
    {
        public Group FromDTO(GroupDTO data)
        {
            return new Group
            {
                Id = data.Id,
                Name = data.Name
            };
        }

        public List<Group> FromDTO(List<GroupDTO> list)
        {
            List<Group> groups = new List<Group>();
            foreach(var item in list)
            {
                groups.Add(this.FromDTO(item));
            }
            return groups;
        }

        public GroupDTO ToDTO(Group data)
        {
            return new GroupDTO
            {
                Id = data.Id,
                Name = data.Name
            };
        }

        public List<GroupDTO> ToDTO(List<Group> list)
        {
            List<GroupDTO> groups = new List<GroupDTO>();
            foreach (var item in list)
            {
                groups.Add(this.ToDTO(item));
            }
            return groups;
        }
    }
}
