using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_LPATR.Models;

namespace E_LPATR.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        [HttpPost]
        public ActionResult Index(User user)
        {
            if (Session["User"] != null) { 
                return View(user);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            ViewSignUp v = new ViewSignUp();
            v.Countries = new LearningHandler().GetCountries().ToSelectListItems();
            return View(v);
        }
        [HttpPost]
        public ActionResult Home()
        {
            if (Session["User"] != null)
            {
                User teacher = Session["User"] as User;
                return View(new LearningHandler().GetProfile(teacher.Id));
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        [HttpPost]
        public ActionResult CreateProfile()
        {
            if (Session["User"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        [HttpGet]
        public ActionResult AddProfile(Profile profile,FormCollection collection)
        {
            User teacher = Session["User"] as User;
            profile.Teacher = teacher;
            new LearningHandler().AddProfile(profile);
            return RedirectToAction("Home",profile);
        }
        public ActionResult OrderPageTeacher()
        {
            if (Session["User"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult Requests()
        {
            if (Session["User"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult Profile()
        {
            if (Session["User"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
    }
}