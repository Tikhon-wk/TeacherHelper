using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherHelper.DAL.Context;
using TeacherHelper.DAL.Interfaces;
using TeacherHelper.DAL.Models;

namespace TeacherHelper.DAL.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private ApplicationContext context;
        public GroupRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public void Create(Group data)
        {
            if (data == null)
                throw new NullReferenceException();
            context.Groups.Add(data);
            context.SaveChanges();
        }

        public void Delete(string id)
        {
            if (id.Trim() == "")
                throw new ArgumentException("Group's id cannot be empty");
            Group group = context.Groups.Find(id);
            if(group == null)
                throw new ArgumentException($"Group with id: {id} does not exist!");
            context.Groups.Remove(group);
            context.SaveChanges();
        }

        public Group Read(string id)
        {
            if (id.Trim() == "")
                throw new ArgumentException("Group's id cannot be empty");
            Group group = context.Groups.Find(id);
            if (group == null)
                throw new ArgumentException($"Group with id: {id} does not exist!");
            return group;
        }

        public List<Group> ReadAll()
        {
            return context.Groups.ToList();
        }

        public void Update(Group data)
        {
            context.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
