using Microsoft.EntityFrameworkCore;
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
    public class TeacherRepository : ITeacherRepository
    {
        private ApplicationContext context;
        public TeacherRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public void AddGroup(string teacherId, string groupId)
        {
            if (String.IsNullOrEmpty(teacherId.Trim()))
                throw new ArgumentException("Teacher's id cannot be null or empty");
            Teacher teacher = context.Teachers.Find(teacherId);
            if (teacher == null)
                throw new ArgumentException($"Teacher with id: {teacherId} doesn't exist");
            Group group = context.Groups.Find(groupId);
            if (group == null)
                throw new NullReferenceException();
            teacher.Groups.Add(group);
            context.SaveChanges();
        }

        public void AddSubject(string teacherId, string subjectId)
        {
            if (String.IsNullOrEmpty(teacherId.Trim()))
                throw new ArgumentException("Teacher's id cannot be null or empty");
            Teacher teacher = context.Teachers.Find(teacherId);
            if (teacher == null)
                throw new ArgumentException($"Teacher with id: {teacherId} doesn't exist");
            Subject subject = context.Subjects.Find(subjectId);
            if (subject == null)
                throw new NullReferenceException();
            teacher.Subjects.Add(subject);
            context.SaveChanges();
        }

        public void Create(Teacher data)
        {
            if (data == null)
                throw new NullReferenceException();
            context.Teachers.Add(data);
            context.SaveChanges();
        }

        public void Delete(string id)
        {
            if (id.Trim() == "")
                throw new ArgumentException("Teacher's id cannot be empty");
            Teacher teacher = context.Teachers.Find(id);
            if (teacher == null)
                throw new ArgumentException($"Teacher with id: {id} is not exist!");
            context.Teachers.Remove(teacher);
            context.SaveChanges();
        }

        public List<Subject> GetSubjects(string teacherId)
        {
            if (String.IsNullOrEmpty(teacherId.Trim()))
                throw new ArgumentException("Teacher's id cannot be null or empty");
            Teacher teacher = context.Teachers.Include(teacher => teacher.Subjects).ToList().FirstOrDefault(t => t.Id == teacherId);
            if (teacher == null)
                throw new ArgumentException($"Teacher with id: {teacherId} doesn't exist");
            return teacher.Subjects;
        }

        public Teacher Read(string id)
        {
            if (id.Trim() == "")
                throw new ArgumentException("Teacher's id cannot be empty");
            Teacher teacher = context.Teachers.Find(id);
            if (teacher == null)
                throw new ArgumentException($"Teacher with id: {id} does not exist!");
            return teacher;
        }

        public List<Teacher> ReadAll()
        {
            return context.Teachers.ToList();
        }

        public void Update(Teacher data)
        {
            context.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
