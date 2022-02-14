using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherHelper.DAL.Context;
using TeacherHelper.DAL.Interfaces;
using TeacherHelper.DAL.Repositories;

namespace TeacherHelper.DAL.Configuration
{
    public static class Configuration
    {
        public static void ConfigureDAL(this IServiceCollection services)
        {
            string connectionString = GetConnectionString("appsettings.json", "ApplicationConnectionString");
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IWorkRepository, WorkRepository>();

            //services.AddIdentity<User,Role>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();
            //services.Configure<IdentityOptions>(options =>
            // {
            //     options.Password.RequireDigit = true;
            //     options.Password.RequiredLength = 6;
            //     options.Password.RequireLowercase = false;
            //     options.Password.RequireNonAlphanumeric = false;
            // });
        }
        //public static void ConfigureIdentityContext<TUser,TRole>(this IServiceCollection services) where TUser : IdentityUser where TRole : IdentityRole
        //{
        //    services.AddIdentity<TUser, TRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();
        //    services.Configure<IdentityOptions>(options =>
        //    {
        //        options.Password.RequireDigit = true;
        //        options.Password.RequiredLength = 6;
        //        options.Password.RequireLowercase = false;
        //        options.Password.RequireNonAlphanumeric = false;
        //    });
        //}
        private static string GetConnectionString(string jsonFileName, string connectionStringName)
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile(jsonFileName);
            var config = builder.Build();
            return config.GetConnectionString(connectionStringName);
        }
    }
}
