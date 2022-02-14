using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherHelper.Models.Identity
{
    public class User:IdentityUser
    {
        public string UserLastname { get; set; }
        public User()
        {

        }
    }
}
