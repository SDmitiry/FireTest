using FireTest.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FireTest.Controllers
{
    [Authorize]
    public class DisciplinesController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        private static Random random = new Random();
        public ActionResult Index(int id = 0)
        {
            //Выбор курса дисциплины
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult IndexCount(int idtest, int course = 1)
        {
            //Показ кол-ва вопросов за выбранный курс
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(int? EndId, int id = 0, string submitButton = "Exit", int count = 10, int course = 1)
        {
            return View();
        }
        public ActionResult DisciplineTest()
        {
            //Тестирование
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult DisciplineTestQuestions(List<string> AnswersIDs)
        {
            //Показ вопроса
            return PartialView();
        }
        public ActionResult DisciplineTestEnd()
        {
            //Завершенеи теста
            return View();
        }
        public ActionResult DisciplineWrongDetails(int id)
        {
            //Выбор правильных/неправильных ответов
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Issue(string QID, string Issue)
        {
            //Отправка сообщения об ошибке
            return View();
        }
        #region Вспомогательные приложения
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
        static void Shuffle<T>(List<T> array)
        {
        }
        private Questions SelectQuestion(int id)
        {
            return new Questions();
        }
        private int CountAnswers(int id)
        {
            return 0;
        }
        private bool SaveAnswer(int id, List<int> AnswersIDs)
        {
            return true;
        }
        #endregion
    }
}