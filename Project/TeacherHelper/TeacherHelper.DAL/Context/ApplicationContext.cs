using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherHelper.DAL.Models;
using TeacherHelper.DAL.Models.ReferenciesManyToMany;

namespace TeacherHelper.DAL.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; private set; }
        public DbSet<Student> Students { get; private set; }
        public DbSet<Subject> Subjects { get; private set; }
        public DbSet<Group> Groups { get; private set; }
        public DbSet<Work> Works { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Teacher>()
        //        .HasMany(left => left.Subjects)
        //        .WithMany(right => right.Teachers)
        //        .UsingEntity<TeacherSubject>
        //        (
        //            right => right.HasOne(e => e.Subject).WithMany().HasForeignKey(e => e.SubjectId),
        //            left => left.HasOne(e => e.Teacher).WithMany().HasForeignKey(e => e.TeacherId),
        //            join => join.ToTable("TeacherSubject")
        //        );
        //    modelBuilder.Entity<Student>()
        //        .HasMany<Work>(left => left.Works)
        //        .WithMany(right => right.Students)
        //        .UsingEntity<WorkStudent>
        //        (
        //            right => right.HasOne(e => e.Work).WithMany().HasForeignKey(e => e.WorkId),
        //            left => left.HasOne(e => e.Student).WithMany().HasForeignKey(e => e.StudentId),
        //            join => join.ToTable("WorkStudent")
        //        );
        //    modelBuilder.Entity<Teacher>()
        //        .HasMany(left => left.Groups)
        //        .WithMany(right => right.Teachers)
        //        .UsingEntity<TeacherGroup>
        //        (
        //            right => right.HasOne(e=>e.Group).WithMany().HasForeignKey(e => e.GroupId),
        //            left => left.HasOne(e=>e.Teacher).WithMany().HasForeignKey(e=>e.TeacherId),
        //            join => join.ToTable("TeacherGroup")
        //        );
        //}
    }
}
