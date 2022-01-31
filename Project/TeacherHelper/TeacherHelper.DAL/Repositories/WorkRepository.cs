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
    public class WorkRepository : IWorkRepository
    {
        private ApplicationContext context;
        public WorkRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public void Create(Work data)
        {
            if (data == null)
                throw new NullReferenceException();
            context.Works.Add(data);
            context.SaveChanges();
        }

        public void Delete(string id)
        {
            if (String.IsNullOrEmpty(id.Trim()))
                throw new ArgumentException("Id cannot be null or empty!");
            Work work = context.Works.Find(id);
            if (work == null)
                throw new ArgumentException($"Work with id:{id} doesn't exist");
            context.Works.Remove(work);
            context.SaveChanges();
        }

        public Work Read(string id)
        {
            if (String.IsNullOrEmpty(id.Trim()))
                throw new ArgumentException("Id cannot be null or empty!");
            Work work = context.Works.Find(id);
            if (work == null)
                throw new ArgumentException($"Work with id:{id} doesn't exist");
            return work;
        }

        public List<Work> ReadAll()
        {
            return context.Works.ToList();
        }

        public void Update(Work data)
        {
            context.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
