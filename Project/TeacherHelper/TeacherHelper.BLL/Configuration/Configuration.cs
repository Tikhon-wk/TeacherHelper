using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherHelper.BLL.Interfaces;
using TeacherHelper.BLL.Services;
using TeacherHelper.DAL.Configuration;

namespace TeacherHelper.BLL.Configuration
{
    public static class Configuration
    {
        public static void ConfigureBLL(this IServiceCollection services)
        {
            services.ConfigureDAL();
            services.AddScoped(typeof(IStudentService),typeof(StudentService));
            services.AddScoped(typeof(IGroupService),typeof(GroupService));
            services.AddScoped(typeof(ITeacherService),typeof(TeacherService));
            services.AddScoped(typeof(ISubjectService),typeof(SubjectService));
        }
    }
}
