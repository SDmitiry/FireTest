using FireTest.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using EntityFramework.Extensions;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Text;

namespace FireTest.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        [AllowAnonymous]
        public ActionResult Mobile()
        {
            return View();
        }
        private bool NewUser(string userID)
        {
            //Проверка нового пользователя на заполненность профиля
            return false;
        }
        public PartialViewResult UserInfo()
        {
            return PartialView();
        }

        public ActionResult Index(ManageController.ManageMessageId? message)
        {
            //Главная страница
            return View();
        }
        public ActionResult RatingPlace()
        {
            //Место в рейтинге
            return View();
        }
        public PartialViewResult Departments()
        {
            //Дисциплины
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult Awards()
        {
            //Кубки
            return PartialView();
        }
    }
}