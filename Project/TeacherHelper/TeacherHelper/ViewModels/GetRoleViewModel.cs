using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherHelper.ViewModels
{
    public class GetRoleViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string RoleName { get; set; }
    }
}
