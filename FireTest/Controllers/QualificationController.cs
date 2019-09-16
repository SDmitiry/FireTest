using FireTest.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FireTest.Controllers
{
    [Authorize]
    public class QualificationController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        private static Random random = new Random();
        private static int[,] relation = new int[6, 6]{
            {100, 0, 0, 0, 0, 0},
            {40, 60, 0, 0, 0, 0},
            {20, 20, 60, 0, 0, 0},
            {10, 10, 20, 60, 0, 0},
            {10, 10, 10, 20, 50, 0},
            {5, 5, 10, 10, 20, 50 }};

        public ActionResult Index(int id = 1)
        {
            //Выбор ко-ва вопросов тестирования по уровню подготовки или предложить продолжить не законченный тест
            return View();
        }
        public ActionResult QualificationTest()
        {
            //Тест
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult QualificationTestQuestions(List<string> AnswersIDs)
        {
            //Вопросы теста
            return PartialView();
        }
        public ActionResult QualificationTestEnd()
        {
            //Вывод результата
            return View();
        }
        public ActionResult QualificationWrongDetails(int id)
        {
            //Детализация верных/неверных
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