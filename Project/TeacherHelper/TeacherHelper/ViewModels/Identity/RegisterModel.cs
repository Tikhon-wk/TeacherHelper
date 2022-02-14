using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherHelper.ViewModels.Identity
{
    public class RegisterModel
    {

        [Required]
        [Display(Name = "Login")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Lastname")]
        public string UserLastname { get; set; }
        [Required]
        [Display(Name = "Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password",ErrorMessage = "Password didn't confirm")]

        [Display(Name = "Password confirm")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}
