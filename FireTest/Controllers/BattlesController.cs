using FireTest.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FireTest.Controllers
{
    [Authorize]
    public class BattlesController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        private static Random random = new Random();
        const int battleQuestions = 20;
        const int timeQuestion = 30;
        public ActionResult Index()
        {
            //Контроллер вызывающий другого пользователя на схватку, если уже идет бой то перенаправляет на него
            return View();
        }
        public PartialViewResult Users()
        {
            //Контроллер выбора противника
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult BattleInvite()
        {
            //Контроллер вызова противника
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult BattleInvitePopup()
        {
            //Контроллер всплывающего окна приглашения для боя для второго игрока
            return PartialView();
        }

        public ActionResult Prepare(string id)
        {
            //Подготовка вопросов и отправка приглашения 
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Prepare(BattleViewModel model)
        {
            return View();
        }
        public ActionResult Wait(int course, int IdBattle)
        {
            //Ожидание согласия 1 минуту
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Wait(int id, string submitButton)
        {
            //Согласие - в бой
            //Нет - на выбор противника
            return View();
        }
        public ActionResult Fight(int? id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult FightQuestions(int id, List<string> AnswersIDs, string afk, int timeAfk = timeQuestion)
        {
            //Вывод вопроса
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult FightQuestionsRoW(int id)
        {
            //Вывод верности своих и противника ответов
            return PartialView();
        }

        public ActionResult BattleEnd(int id)
        {
            //Конец боя
            return View();
        }
        [HttpPost]
        public PartialViewResult BattleEndWait(int id)
        {
            //Ожидание второго игрока
            return PartialView();
        }
        public ActionResult Finish(int id)
        {
            //Показ победителя
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