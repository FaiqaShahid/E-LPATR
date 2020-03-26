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
            v.Countries = new LearningHandler().GetCountries().ToSelectListItems();
            return View(v);
        }
        public ActionResult Home(string Email)
        {
            User user = new LearningHandler().GetUserByEmail(Email);
            return View(user);
        }
        public ActionResult CreateProfile(int Id)
        {
            return View(new LearnContext().Users.Find(Id));
        }
        public ActionResult AddProfile(Profile profile)
        {
            new LearningHandler().AddProfile(profile);
            return RedirectToAction("Home");
        }
        public ActionResult OrderPageTeacher()
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