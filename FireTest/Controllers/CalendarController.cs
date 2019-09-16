using FireTest.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FireTest.Controllers
{
    [Authorize]
    public class CalendarController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        public ActionResult Index()
        {     
            return View();
        }
    }
}