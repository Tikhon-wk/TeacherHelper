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
        ///// <summary>
        ///// very very very Shit code
        ///// </summary>
        ///// <param name="action"></param>
        ///// <param name="actionName"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public IActionResult Index(string action, string actionName)
        //{
        //    string result = "";
        //    if (actionName == "Show")
        //        result = actionName + action + "s";
        //    else
        //        result = actionName + action;
        //    if (action == "Index")
        //        return RedirectToAction("Index");
        //    return RedirectToAction(result);
        //}

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
            return View(groupService.ReadAll().OrderBy(g => g.Name).ToList());
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
            return RedirectToAction("ShowGroups");
        }
        [HttpGet]
        public IActionResult AddTeacher()
        {
            return View();
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
        [HttpGet]
        public IActionResult AddSubject()
        {
            return View();
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
            return Redirect("Index");
        }
        [HttpGet]
        public IActionResult AddSubjectsToTeacher(string id)
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
    }
}
