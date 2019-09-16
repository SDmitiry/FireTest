using FireTest.Models;
using Microsoft.AspNet.Identity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
using System.Web.Mvc;

namespace FireTest.Controllers
{
    [Authorize]
    public class StatisticsController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        public ActionResult IndexUser()
        {
            return View();
        }
        [Authorize(Roles = "ADMIN, TEACHER")]
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult UserStatistics()
        {
            //Статистика пользователя
            return PartialView();
        }
        public PartialViewResult CountBattles(string userId)
        {
            //Кол-во схваток
            return PartialView();
        }
        public PartialViewResult CountAnswers(string userId)
        {
            //Кол-во ответов
            return PartialView();
        }
        public ActionResult Groups()
        {
            //Статистика групп
            return View();
        }
        [HttpPost]
        public PartialViewResult Groups(string Groups, int Statistics, int? DateRange)
        {
            return PartialView();
        }
        public ActionResult Courses()
        {
            //Статистика курсов
            return View();
        }
        [HttpPost]
        public PartialViewResult Courses(string Courses, int Statistics, int? DateRange)
        {
            return PartialView();
        }

        public ActionResult Users()
        {
            //Список пользователей
            return View();
        }
        public PartialViewResult UsersAjax(string currentFilter, string searchString, int? page, string Group)
        {
            return PartialView();
        }
        public ActionResult UsersStatistics(string id)
        {
            return View();
        }
        [HttpPost]
        public PartialViewResult UsersStatistics(string Id, int Statistics, int? DateRange)
        {
            return PartialView();
        }
        public ActionResult CompareGroups()
        {
            //Сравнение групп
            return View();
        }
        [HttpPost]
        public PartialViewResult CompareGroups(string Group1, string Group2, int Statistics, int? DateRange)
        {
            return PartialView();
        }
        public ActionResult CompareCourses()
        {
            //Сравнение курсов
            return View();
        }
        [HttpPost]
        public PartialViewResult CompareCourses(string Course1, string Course2, int Statistics, int? DateRange)
        {
            return PartialView();
        }
        private List<SelectListItem> ListDataRange(int DataRange)
        {
            //Выбор периода 
            return null;
        }
    }
}