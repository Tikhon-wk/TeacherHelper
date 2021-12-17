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
    public class SubjectRepository : ISubjectRepository
    {
        private ApplicationContext context;
        public SubjectRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public void Create(Subject data)
        {
            if (data == null)
                throw new NullReferenceException();
            context.Subjects.Add(data);
            context.SaveChanges();
        }

        public void Delete(string id)
        {
            if (id.Trim() == "")
                throw new ArgumentException("Subject's id cannot be empty");
            Subject subject = context.Subjects.Find(id);
            if (subject == null)
                throw new ArgumentException($"Subject with id: {id} does not exist");
            context.Subjects.Remove(subject);
            context.SaveChanges();
        }

        public Subject Read(string id)
        {
            if (id.Trim() == "")
                throw new ArgumentException("Subject's id cannot be empty");
            Subject subject = context.Subjects.Find(id);
            if (subject == null)
                throw new ArgumentException($"Subject with id: {id} does not exist");
            return subject;
        }

        public List<Subject> ReadAll()
        {
            return context.Subjects.ToList();
        }

        public void Update(Subject data)
        {
            context.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
