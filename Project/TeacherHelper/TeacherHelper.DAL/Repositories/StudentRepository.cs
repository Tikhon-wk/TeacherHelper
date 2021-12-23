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
    public class StudentRepository : IStudentRepository
    {

        private ApplicationContext context;
        public StudentRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public void Create(Student data)
        {
            if (data == null)
                throw new NullReferenceException();
            Group group = context.Groups.Find(data.GroupId);
            if (group == null)
                throw new ArgumentException($"Cannot create student because group with id: {data.GroupId} doesn't exist");
            data.Group = group;
            context.Students.Add(data);
            context.SaveChanges();
        }

        public void Delete(string id)
        {
            if (id.Trim() == "")
                throw new ArgumentException("Student's id cannot be empty");
            Student student = context.Students.Find(id);
            if (student == null)
                throw new ArgumentException($"Student with id: {id} is not exist!");
            context.Students.Remove(student);
            context.SaveChanges();
        }

        public Student Read(string id)
        {
            if (id.Trim() == "")
                throw new ArgumentException("Student's id cannot be empty");
            Student student = context.Students.Find(id);
            if (student == null)
                throw new ArgumentException($"Student with id: {id} does not exist!");
            return student;
        }

        public List<Student> ReadAll()
        {
            return context.Students.ToList();
        }

        public void Update(Student data)
        {
            context.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
