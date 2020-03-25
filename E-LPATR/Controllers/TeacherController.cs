using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_LPATR.Models;

namespace E_LPATR.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SignUp()
        {
            ViewSignUp v = new ViewSignUp();
            v.Countries = new LeaningHelper().GetCountries().ToSelectListItems();
            return View(v);
        }
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult OrderPageTeacher()
        {
            return View();
        }
        public ActionResult CreateProfile()
        {
            return View();
        }
        public ActionResult Requests()
        {
            return View();
        }
        public ActionResult Profile()
        {
            return View();
        }
    }
}