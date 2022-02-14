using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherHelper.Models.Identity;

namespace TeacherHelper.ViewModels
{
    public class ProfileViewModel
    {
        public string ImagePath { get; set; } = "~/img/naruto-icon-14688.png";
        public User User { get; set; }
    }
}
