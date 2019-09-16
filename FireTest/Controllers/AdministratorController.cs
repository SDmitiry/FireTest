using FireTest.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using EntityFramework.Extensions;
using System.Drawing;

namespace FireTest.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class AdministratorController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MessageOfTheDay()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MessageOfTheDay(MessageOfTheDayViewModel model)
        {
            return View();
        }
        public ActionResult Users()
        {
            return View();
        }
        public PartialViewResult UsersAjax(string currentFilter, string searchString, int? page, string submitButton, int? Page)
        {
            //Контроллер отображающий всех пользователей, и предоставляющий возмножсть назначит админа и препода
            return PartialView();
        }
        public ActionResult SelectTeacher()
        {
            return View();
        }
        public PartialViewResult SelectTeacherAjax(string currentFilter, string searchString, int? page, string submitButton)
        {
            //Контроллер отображающий всех преподов
            return PartialView();
        }
        public ActionResult TeacherDisciplines(string userId)
        {
            return View();
        }
        public PartialViewResult TeacherDisciplinesAjax(string currentFilter, string searchString, int? page, int? submitButton, int? Page, string userId, bool submitButtonAll = false)
        {
            //Контроллер отображающий к каким дисциплинам есть доступ у преподавателя, с возможностью выбора
            return PartialView();
        }
        //Остальные контроллеры понятны по названию
        public ActionResult DeleteUser(string id)
        {
            return View();
        }
        [HttpPost, ActionName("DeleteUser")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUserConfirmed(string id)
        {
            return View();
        }
        public ActionResult AddDiscipline()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDiscipline(string NameDiscipline, int Department)
        {
            return View();
        }
        public ActionResult DeleteDiscipline(string StatusMessage)
        {
            return View();
        }
        public ActionResult DeleteDisciplineConfirm(string value)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDisciplineConfirm(int DisciplinesDelete, int DisciplinesTransfer)
        {
            return View();
        }
        public ActionResult SelectTeacherStatistic()
        {
            return View();
        }
        public PartialViewResult SelectTeacherStatisticAjax(string currentFilter, string searchString, int? page, int? Page, string submitButton)
        {
            return PartialView();
        }
        public ActionResult TeacherStatistic(string userId)
        {
            return View();
        }
        public ActionResult Faculties()
        {
            return View();
        }
        public ActionResult CreateFaculty()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateFaculty(FacultyViewQualifications model)
        {
            return View();
        }
        string SaveFacultyPictures(string LevelPicture, List<string> levelsPictures = null)
        {
            return null;
        }
        public ActionResult AddQualification(FacultyViewQualifications model)
        {
            return PartialView();
        }
        public ActionResult DeleteFaculty(int id)
        {
            return View();
        }
        [HttpPost, ActionName("DeleteFaculty")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFacultyConfirmed(int id)
        {
            return View();
        }
        public ActionResult ViewFaculty(int id)
        {
            return View();
        }
        public ActionResult EditFaculty(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult EditFaculty(FacultyViewQualifications model)
        {
            return View();
        }
    }
}