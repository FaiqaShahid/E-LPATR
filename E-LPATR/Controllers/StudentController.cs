using E_LPATR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_LPATR.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }
        
        public ActionResult OrderPage()
        {
            return View();
        }
        public ActionResult RecentOrders()
        {
            return View();
        }
        public ActionResult SentRequestRequirements()
        {
            return View();
        }
        public ActionResult Settings()
        {
            return View();
        }
        public ActionResult GiveReview()
        {
            return View();
        }
    }
}