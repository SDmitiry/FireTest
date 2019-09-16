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
    public class ExaminationController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        private static Random random = new Random();
        public PartialViewResult Access()
        {
            //Показывает какие экзамены и есть ли допуск. И предлагает начать если допуск есть
            return PartialView();
        }
        public ActionResult Index(int? id)
        {
            //Начинаем экзамен
            return View();           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult Questions(List<string> AnswersIDs, int? IDEXAM)
        {
            //Вопрос экзамена
            return PartialView();
            
        }
        public ActionResult End(int? IDEXAM)
        {
            //Ставим оценку
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
        private bool AutoSelectQuestion(int id, string faculty)
        {
            return true;
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