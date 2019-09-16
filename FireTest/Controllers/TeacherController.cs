using FireTest.Models;
using Microsoft.AspNet.Identity;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using EntityFramework.Extensions;
using System.Data.Entity;
using System.Text.RegularExpressions;
using System.Drawing;

namespace FireTest.Controllers
{
    [Authorize(Roles = "ADMIN, TEACHER")]
    public class TeacherController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        public PartialViewResult IndexIssues(int? page, int? submitButton)
        {
            //Показ ошибок от пользователя
            return PartialView();
        }
        public ActionResult Index(string message)
        {
            //Какие тесты есть у препода
            return View();
        }
        [ChildActionOnly]
        public ActionResult IndexExams()
        {
            //Какие экзамены у препода
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult IndexQualification()
        {            
            //Какие финальные экзамены у препода
            return PartialView();
        }
        public ActionResult Details(int? id)
        {
            //Подробности теста
            return View();
        }
        public ActionResult Delete(int? id)
        {
            //Удаление теста
            return View();
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            return View();
        }
        public ActionResult CreateTest()
        {
            //Создание теста
            return View();
        }
        public PartialViewResult CreateTestAjax(string currentFilter, string searchString, int? page, string NameTest, int? Subjects, string Tags, int? submitButton, List<int> Eval)
        {
            return PartialView();
        }
        public ActionResult Edit(int? id)
        {
            //Редактирование теста
            return View();
        }

        public ActionResult CreateTestFinish(int idTest)
        {
            //Создание финального тестирования
            return View();
        }
        public PartialViewResult CreateTestFinishAjax(string currentFilter, string searchString, int? page, int? submitButton, bool submitButtonAll = false)
        {
            return PartialView();
        }

        public ActionResult NewQuestion(string Message, int? Department, int? Subject, int? Course, string SelectedTag)
        {
            //Создание нового вопроса
            return View();
        }
        [HttpPost]
        public ActionResult UpdateTags(int? Subjects)
        {  
            //Обновление раздела дисциплины
            return Json(new { Success = "true"});
        }
        [HttpPost]
        public ActionResult NewQuestion(ViewCreateQuestion model, int Subjects, int Departments, int Courses, int Type, string OldTags, List<string> AnswersSequence, List<string> AnswersConformity, HttpPostedFileBase uploadfile, List<string> Faculties)
        {
            //Сохранение вопроса
            return View();
        }
        public ActionResult EditQuestion(string message, string Message, int? Subjects, string Tags)
        {
            //Редактирование вопроса
            return View();
        }
        [HttpPost]
        public ActionResult EditQuestion(ViewEditQuestion Question, int Type, int id, int Subjects, int Departments, int Courses, string Delete, HttpPostedFileBase uploadfile, int OldSubjects, string OldTags, List<string> Faculties, List<string> AnswersSequence, List<string> AnswersConformity)
        {
            return View();
        }
        public ActionResult DeleteQuestion(int? id)
        {
            return View();
        }
        [HttpPost, ActionName("DeleteQuestion")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteQuestionConfirmed(int id, string Action)
        {
            return View();
        }
        [HttpPost]
        public ActionResult QuestionQualification(int id, int? QualificationsList, string Action)
        {
            //Добавить/убрать вопрос в квалификацию
            return View();
        }
        public ActionResult CreateExam()
        {
            //Создать экзамен
            return View(new ExaminationViewModel() { Date = DateTime.Now });
        }
        [HttpPost]
        public ActionResult CreateExam(ExaminationViewModel model, string Group, string Test)
        {
            return View();
        }
        public ActionResult EditExams(int? id, string message)
        {
            //Редактировать экзамен
            return View();
        }
        [HttpPost]
        public ActionResult EditExams(ExaminationViewModel model, string Group, string Test, int id)
        {
            return View();
        }
        public ActionResult DeleteExams(int? id)
        {
            return View();
        }
        public ActionResult DetailsExams(int? id)
        {
            //Подробности экзамена
            return View();
        }
        public ActionResult ExamAccess(int? id)
        {
            //Дать доступ к экзамену
            return View();
        }
        public PartialViewResult ExamAccessAjax(string currentFilter, string searchString, int? page, string submitButton, bool submitButtonAll = false)
        {
            return PartialView();
        }
        public ActionResult ResumeExams(int? id)
        {
            //Итог экзамена
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}