using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherHelper.BLL.Interfaces;
using TeacherHelper.ViewModels;
using TeacherHelper.Models.Identity;
using TeacherHelper.ViewModels.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Net.Mail;
using System.Net;

namespace TeacherHelper.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //userService.Authenticate(model.Email, model.Password, model.RememberMe);
                    var result = signInManager.PasswordSignInAsync(model.Login, model.Password, model.RememberMe, false).Result;
                    if (result.Succeeded)
                        return RedirectToAction("Index", "Home");
                    else
                    {
                        ModelState.AddModelError("", "Wrong password or login!!!Try again.");
                    }
                }
                catch { }
            }
            return View(model);
        }
        public IActionResult Logout()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    User user = new User
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = model.Email,
                        UserLastname = model.UserLastname,
                        UserName = model.UserName
                    };
                    var result = userManager.CreateAsync(user, model.Password).Result;
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, "Guest");
                        await signInManager.SignInAsync(user, false);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                };
            }
            return View(model);
        }
        public IActionResult Profile()
        {
            return View(new ProfileViewModel { ImagePath = "~/img/naruto-icon-14688.png", User = userManager.GetUserAsync(this.User).Result });
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public IActionResult AddRole()
        {
            return PartialView();
        }
        //Показ ошибкиs

        [HttpPost]
        public IActionResult AddRole(AddRoleViewModel model)
        {
            User current = userManager.GetUserAsync(this.User).Result;
            //current = null;
            if (current == null)
            {
                ModelState.AddModelError("", "We cannot find current user!");
                //return RedirectToAction("Index", "Home");
                return RedirectToAction("Profile");
            }
            var result = userManager.AddToRoleAsync(current, model.RoleName).Result;
            if (!result.Succeeded)
                ModelState.AddModelError("", "Couldn't add role to user!");
            //return RedirectToAction("Index","Home");
            return RedirectToAction("Profile");
        }
        [HttpGet]
        public IActionResult RedactProfile(string imagePath)
        {
            return View(new ProfileViewModel { ImagePath = imagePath, User = userManager.GetUserAsync(this.User).Result });
        }
        [HttpPost]
        public IActionResult RedactProfile(ProfileViewModel viewModel)
        {
            User user = userManager.GetUserAsync(this.User).Result;
            user.Email = viewModel.User.Email;
            user.UserName = viewModel.User.UserName;
            user.UserLastname = viewModel.User.UserLastname;
            var result = userManager.UpdateAsync(user).Result;
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                    ModelState.AddModelError("", item.Description);
                return RedirectToAction("RedactProfile", viewModel);
            }
            return RedirectToAction("Profile");
        }
        [HttpGet]
        public IActionResult RequestToGetRole()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult RequestToGetRole(GetRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (String.IsNullOrEmpty(model.RoleName))
                    ModelState.AddModelError("", "You didn't choose the role");
                else
                {
                    List<User> admins = userManager.Users.Where(u => userManager.IsInRoleAsync(u, "Admin").Result).ToList();
                    User current = userManager.GetUserAsync(this.User).Result;

                    SmtpClient client = new SmtpClient("smtp.mail.ru", 25);
                    client.Credentials = new NetworkCredential(current.Email, model.Password);
                    client.EnableSsl = false;
                    client.UseDefaultCredentials = true;

                    foreach (var admin in admins)
                    {
                        MailAddress to = new MailAddress(admin.Email);
                        MailAddress from = new MailAddress(current.Email, current.UserName);
                        MailMessage message = new MailMessage(from, to);
                        message.Subject = "Getting a role";
                        message.Body = $"<h2>I want to get {model.RoleName} role</h2>";
                        message.IsBodyHtml = true;
                        client.Send(message);
                    }
                }
            }
            return RedirectToAction("Profile");
        }

        [HttpGet]
        public IActionResult AddRoleToOther()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult AddRoleToOther(AddRoleToOther model)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin"))
                {
                    User user = userManager.FindByNameAsync(model.UserName).Result;
                    if (user == null)
                    {
                        ModelState.AddModelError("", $"User with name {model.UserName} doesn't exist");
                        return PartialView();
                    }
                    var result = userManager.AddToRoleAsync(user, model.Role).Result;
                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                            ModelState.AddModelError("", error.Description);
                        return PartialView();
                    }
                }
            }
            return RedirectToAction("Profile");
        }
    }
}
