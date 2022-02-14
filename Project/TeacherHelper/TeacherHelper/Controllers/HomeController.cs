using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
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
using TeacherHelper.ViewModels;

namespace TeacherHelper.Controllers
{
    public class HomeController : Controller
    {
        private IStudentService studentService;
        private IGroupService groupService;
        private ITeacherService teacherService;
        private ISubjectService subjectService;
        public HomeController(IStudentService studentService, IGroupService groupService, ITeacherService teacherService, ISubjectService subjectService)
        {
            this.studentService = studentService;
            this.groupService = groupService;
            this.teacherService = teacherService;
            this.subjectService = subjectService;
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
        // Add modal window error
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AddStudent()
        {
            if(User.IsInRole("Admin"))
            {
                List<GroupDTO> groups = groupService.ReadAll();
                if (groups.Count != 0)
                {
                    return View(groups.OrderBy(g => g.Name).ToList());
                }
                return RedirectToAction("ShowStudentError");
            }
            return Error();
        }
        [HttpPost]
        public IActionResult AddStudent(string studentName, string studentSurname, double studentAvarageMark, string groupId)
        {
            studentService.Create(new StudentDTO
            {
                Id = Guid.NewGuid().ToString(),
                Name = studentName,
                Surname = studentSurname,
                AvarageMark = studentAvarageMark,
                GroupId = groupId
            });
            return RedirectToAction("ShowStudents");
        }
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AddGroup()
        {
            if (User.IsInRole("Admin"))
            {
                return View();
            }
            return Error();
        }
        [HttpPost]
        public IActionResult AddGroup(string groupName)
        {
            groupService.Create(new GroupDTO
            {
                Id = Guid.NewGuid().ToString(),
                Name = groupName
            });
            return RedirectToAction("ShowGroups");
        }
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AddTeacher()
        {
            if(User.IsInRole("Admin"))
            {
                return View();
            }
            return Error();
        }
        [HttpPost]
        public IActionResult AddTeacher(string teacherName, string teacherSurname)
        {
            teacherService.Create(new TeacherDTO
            {
                Id = Guid.NewGuid().ToString(),
                Name = teacherName,
                Surname = teacherSurname
            });
            return RedirectToAction("ShowTeachers");
        }
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AddSubject()
        {
            if(User.IsInRole("Admin"))
            {
                return View();
            }
            return Error();
        }
        [HttpPost]
        public IActionResult AddSubject(string subjectName, int subjectHours)
        {
            subjectService.Create(new SubjectDTO
            {
                Id = Guid.NewGuid().ToString(),
                Name = subjectName,
                Hours = subjectHours
            });
            return Redirect("ShowSubjects");
        }
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AddSubjectsToTeacher(string id)
        {
            if(User.IsInRole("Admin"))
            {
                TeacherDTO teacher = teacherService.Read(id);
                List<SubjectDTO> teacherSubjects = teacherService.GetSubjects(id);
                List<SubjectDTO> allowToAdd = new List<SubjectDTO>();
                foreach (var item in subjectService.ReadAll())
                {
                    if (teacherSubjects.FirstOrDefault(s => s.Id == item.Id) == null)
                    {
                        allowToAdd.Add(item);
                    }
                }
                if (allowToAdd.Count != 0)
                {
                    return View(new AddSubjectsToTeacherViewModel
                    {
                        Subjects = allowToAdd,
                        Teacher = teacher
                    });
                }
                return RedirectToAction("ShowTeachers");
            }
            return Error();
        }
        [HttpPost]
        public IActionResult AddSubjectsToTeacher(string teacherId = "", string subjectsIds = "")
        {
            List<string> subjects = subjectsIds.Split(';').ToList();
            if (subjects.Count != 0)
            {
                foreach (var item in subjects)
                {
                    teacherService.AddSubject(teacherId.Trim(), item.Trim());
                }
            }

            return RedirectToAction("ShowTeachers");
        }

        public IActionResult ShowTeachers()
        {
            return View(teacherService.ReadAll());
        }
        public IActionResult ShowSubjects()
        {
            return View(subjectService.ReadAll().OrderBy(s => s.Hours).ToList());
        }
        public IActionResult ShowStudents()
        {
            ///Shit code
            List<ShowStudentViewModel> list = studentService.ReadAll().Select(
                s => new ShowStudentViewModel
                {
                    Student = s,
                    Group = groupService.Read(s.GroupId)
                }).OrderBy(s => s.Student.AvarageMark).ToList();
            return View(list);
        }
        public IActionResult ShowGroups()
        {
            return View(groupService.ReadAll());
        }

        public IActionResult ShowStudentError()
        {
            return View();
        }
        public IActionResult Photo()
        {
            
            return PartialView();
        }
        [HttpGet]
        public IActionResult ChangeLanguage(string cultures,string returnUrl)
        {
            HttpContext.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cultures)),
                new CookieOptions { Expires = DateTime.Now.AddYears(1)}
                );
            return Redirect(returnUrl);
        }
    }
}
