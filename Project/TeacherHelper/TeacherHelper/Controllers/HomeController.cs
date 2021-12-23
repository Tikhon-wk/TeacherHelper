using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TeacherHelper.BLL.Interfaces;
using TeacherHelper.BLL.ModelsDTO;
using TeacherHelper.Models;

namespace TeacherHelper.Controllers
{
    public class HomeController : Controller
    {
        private IStudentService studentService;
        private IGroupService groupService;
        private ITeacherService teacherService;
        public HomeController(IStudentService studentService, IGroupService groupService,ITeacherService teacherService)
        {
            this.studentService = studentService;
            this.groupService = groupService;
            this.teacherService = teacherService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View(groupService.ReadAll());
        }
        [HttpPost]
        public IActionResult AddStudent(string studentName, string studentSurname, string groupId)
        {
            studentService.Create(new StudentDTO   
            {
                Id = Guid.NewGuid().ToString(),
                Name = studentName,
                Surname = studentSurname,
                GroupId = groupId
            });
            return Redirect("Index");
        }
        [HttpGet]
        public IActionResult AddGroup()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddGroup(string groupName)
        {
            groupService.Create(new GroupDTO
            {
                Id = Guid.NewGuid().ToString(),
                Name = groupName
            });
            return Redirect("Index");
        }
        [HttpGet]
        public IActionResult AddTeacher()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTeacher(string teacherName)
        {
            
            return Redirect("Index");
        }
        [HttpGet]
        public IActionResult AddSubject()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSubject(string teacherName)
        {

            return Redirect("Index");
        }
    }
}
