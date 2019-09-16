using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using FireTest.Models;
using System.Collections.Generic;
using System.IO;
using System.Web.Helpers;
using System.Security.Cryptography;

namespace FireTest.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        ApplicationDbContext dbContext = new ApplicationDbContext();

        public ManageController()
        {
        }

        public ManageController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public async Task<ActionResult> Index(ManageMessageId? message, string NewFaculty)
        {
            //Личный кабинет
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(IndexViewModel model)
        {
            return View();
        }

        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> Edit(string id, ManageMessageId? message, string NewFaculty)
        {
            //Поправить пользователя админом
            return View();
        }
        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditViewModel model, string UserId)
        {
            return View();
        }

        private async Task<IdentityResult> UpdateUserAsync(string userId, IndexViewModel model)
        {            
            //Поправить пользователя самому
            return IdentityResult.Success;
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            return View();
        }

        [HttpGet]
        public ActionResult AvatarUpload()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<ActionResult> SaveAvatar(string fileName)
        {
            return Json(new { success = true });
        }

        #region Вспомогательные приложения
        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            ChangeSuccess,
            Error
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            base.Dispose(disposing);
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        private List<SelectListItem> Region(string userRegion)
        {
            //Список регионов
            return null;
        }
        private List<SelectListItem> Faculty(string userFaculty)
        {
            //Список факультетов
            return null;
        }
        private List<SelectListItem> Speciality(string userSpeciality)
        {
            //Выбор кафедры
            return null;
        }
        #endregion
    }
}